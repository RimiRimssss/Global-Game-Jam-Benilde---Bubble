using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float scaleFactor = 0.001f;
    [SerializeField] private float moveSpeed = 3.0f;
    [SerializeField] private float bubbleLimit = 3.0f;
    [SerializeField] private float bubbleTimer;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //Expanding Bubble
        if (Input.GetKey(KeyCode.Space))
        {
            transform.localScale += Vector3.one * scaleFactor;
            rb2d.gravityScale = -1.0f;
            rb2d.gravityScale += -0.05f;
        }
        else if (Input.GetKey(KeyCode.Space) == false)
        {
            transform.localScale -= Vector3.one * scaleFactor;
            rb2d.gravityScale = 1.0f;

            bubbleTimer = 0;

            if (transform.localScale.x < 1) transform.localScale = Vector3.one;
        }

        if (transform.localScale.x >= bubbleLimit) 
        {
            transform.localScale = Vector3.one * bubbleLimit;
        }

        if (transform.localScale.x == bubbleLimit)
        {
            if (bubbleTimer >= 300)
            {
                Destroy(this.gameObject);
            }

            else
            {
                bubbleTimer++;
            }
        }
        //Left and Right
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * Time.deltaTime * moveSpeed;
        }
    }
}
