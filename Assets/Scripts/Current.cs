using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Current : MonoBehaviour
{
    public enum Directions // possible directions for the sea current
    {
        Left,
        Right,
        Up,
        Down
    }

    [SerializeField] private float currentForce = 0.5f; // current speed

    public Directions directions;

    private void OnTriggerStay2D(Collider2D collision)
    {
        Rigidbody2D collisionRb2d = collision.GetComponent<Rigidbody2D>();
        Debug.Log("current is pushing");
        if(collisionRb2d != null)
        {
            switch (directions)
            {
                case (Directions.Left):
                    collisionRb2d.AddForce(Vector3.left * currentForce, ForceMode2D.Impulse);
                    break;

                case (Directions.Right):
                    collisionRb2d.AddForce(Vector3.right * currentForce, ForceMode2D.Impulse);
                    break;
                case (Directions.Up):
                    collisionRb2d.AddForce(Vector3.up * currentForce, ForceMode2D.Impulse);
                    break;
                case (Directions.Down):
                    collisionRb2d.AddForce(Vector3.down * currentForce, ForceMode2D.Impulse);
                    break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Rigidbody2D collisionRb2d = collision.GetComponent<Rigidbody2D>();
        if(collisionRb2d != null)
        collisionRb2d.AddForce(Vector3.zero, ForceMode2D.Impulse);
    }
}
