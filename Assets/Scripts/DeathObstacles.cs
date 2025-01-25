using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathObstacles : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {  
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("YOU HIT");
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("YOU HIT");
            Destroy(collision.gameObject);
        }
    }
}
