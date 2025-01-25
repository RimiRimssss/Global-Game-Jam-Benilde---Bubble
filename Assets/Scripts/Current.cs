using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Current : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        Rigidbody2D collisionRb2d = collision.GetComponent<Rigidbody2D>();
        if(collisionRb2d != null)
        {
            collisionRb2d.AddForce(Vector3.up * 0.5f, ForceMode2D.Impulse);
        }
    }
}
