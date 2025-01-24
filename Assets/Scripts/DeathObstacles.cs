using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathObstacles : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("YOU HIT");
            Destroy(collision.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
