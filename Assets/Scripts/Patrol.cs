using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField]
    private float patrolDistance = 10f; // Maximum distance the object can move from its starting position

    [SerializeField]
    private float speed = 4f; // Speed of the patrol movement

    private Vector2 rootPosition; // The starting position of the object
    private bool movingRight = true; // Direction flag

    void Start()
    {
        // Save the root position at the start
        rootPosition = transform.position;
    }

    void Update()
    {
        PatrolMovement();
    }

    private void PatrolMovement()
    {
        // Calculate the left and right bounds
        float leftLimit = rootPosition.x - patrolDistance;
        float rightLimit = rootPosition.x + patrolDistance;

        // Move the object left or right
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            // If the object reaches the right limit, change direction
            if (transform.position.x >= rightLimit)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);

            // If the object reaches the left limit, change direction
            if (transform.position.x <= leftLimit)
            {
                movingRight = true;
            }
        }
    }
}
