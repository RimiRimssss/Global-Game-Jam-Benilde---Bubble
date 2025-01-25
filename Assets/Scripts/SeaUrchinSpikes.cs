using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaUrchinSpikes : MonoBehaviour
{
    [SerializeField]
    private int spikeCount = 8; // Number of spikes to spawn

    [SerializeField]
    private GameObject spike; // Prefab for the spike

    [SerializeField]
    private float radius = 5f; // Radius for direction calculation

    [SerializeField]
    private float moveSpeed = 5f; // Speed of the spikes

    [SerializeField]
    private float fireInterval = 5f; // Time between automatic firing

    [SerializeField]
    private Transform player; // Reference to the player's Transform

    [SerializeField]
    private float triggerDistance = 7f; // Distance at which shooting starts

    [SerializeField]
    private float stopDistance = 10f; // Distance at which shooting stops

    private Transform parentTransform; // The parent object's transform
    private bool isShooting = false; // Whether the shooter is currently firing

    void Start()
    {
        parentTransform = transform; // Store the parent object's transform
    }

    void Update()
    {
        // Check the distance between the shooter and the player
        float distanceToPlayer = Vector2.Distance(parentTransform.position, player.position);

        // Start shooting if the player is within the trigger distance
        if (!isShooting && distanceToPlayer <= triggerDistance)
        {
            isShooting = true;
            InvokeRepeating(nameof(SpawnProjectiles), 0f, fireInterval);
        }
        // Stop shooting if the player is farther than the stop distance
        else if (isShooting && distanceToPlayer > stopDistance)
        {
            isShooting = false;
            CancelInvoke(nameof(SpawnProjectiles));
        }
    }

    private void SpawnProjectiles()
    {
        float angleStep = 360f / spikeCount;
        float angle = 0f;

        for (int i = 0; i < spikeCount; i++)
        {
            // Calculate the direction of each spike
            float projectileDirXposition = parentTransform.position.x + Mathf.Sin(angle * Mathf.Deg2Rad) * radius;
            float projectileDirYposition = parentTransform.position.y + Mathf.Cos(angle * Mathf.Deg2Rad) * radius;

            Vector2 projectileVector = new Vector2(projectileDirXposition, projectileDirYposition);
            Vector2 projectileMoveDirection = (projectileVector - (Vector2)parentTransform.position).normalized * moveSpeed;

            // Instantiate and set velocity for the spike
            GameObject proj = Instantiate(spike, parentTransform.position, Quaternion.identity);
            Rigidbody2D rb = proj.GetComponent<Rigidbody2D>();
            rb.velocity = projectileMoveDirection;

            // Rotate the spike to face its direction of travel
            float rotationAngle = Mathf.Atan2(projectileMoveDirection.y, projectileMoveDirection.x) * Mathf.Rad2Deg - 90f;
            proj.transform.rotation = Quaternion.Euler(0, 0, rotationAngle);

            // Add the collision handling script to the spike
            SpikeBehavior spikeBehavior = proj.AddComponent<SpikeBehavior>();
            spikeBehavior.parentGameObject = gameObject;

            angle += angleStep;
        }
    }
}

public class SpikeBehavior : MonoBehaviour
{
    [HideInInspector]
    public GameObject parentGameObject; // Reference to the parent object

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Destroy the spike if it collides with anything other than the parent or other spikes
        if (collision.gameObject != parentGameObject && !collision.gameObject.CompareTag("Spike"))
        {
            // Destroy the spike itself
            Destroy(gameObject);
        }
    }
}
