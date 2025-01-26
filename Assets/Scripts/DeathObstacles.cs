using System.Collections;
using UnityEngine;

public class DeathObstacles : MonoBehaviour
{
    [SerializeField]
    private float playerDisableDelay = 0f; // Delay before disabling the player

    public GameManager gameManager; // Reference to the GameManager

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("YOU HIT");
            StartCoroutine(DisablePlayerAfterDelay(collision.gameObject));
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("YOU HIT");
            StartCoroutine(DisablePlayerAfterDelay(collision.gameObject));
        }
    }

    private IEnumerator DisablePlayerAfterDelay(GameObject player)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(playerDisableDelay);

        // Disable the player GameObject
        player.SetActive(false);
    }

}
