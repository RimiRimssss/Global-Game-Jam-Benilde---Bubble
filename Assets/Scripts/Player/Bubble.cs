using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] private float scaleFactor = 0.01f;
    [SerializeField] private float bubbleLimit = 3.0f;
    [SerializeField] private float bubbleTimer;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //Expanding Bubble
        if (Input.GetKey(KeyCode.Space))
        {
            transform.localScale += Vector3.one * scaleFactor;
            //rb2d.gravityScale = -1.0f;
            //rb2d.gravityScale += -0.1f;
        }
        else if (Input.GetKey(KeyCode.Space) == false)
        {
            transform.localPosition = Vector3.zero;
            transform.localScale -= Vector3.one * scaleFactor / 2;
            //rb2d.gravityScale = 1.0f;

            bubbleTimer = 0;

            if (transform.localScale.x < 1) transform.localScale = Vector3.one;
        }

        if (transform.localScale.x >= bubbleLimit)
        {
            transform.localScale = Vector3.one * bubbleLimit;
        }

        if (transform.localScale.x == bubbleLimit)
        {
            if (bubbleTimer >= 120)
            {
                Debug.Log("TOO BIG BOI");
                Destroy(this.gameObject);
            }

            else
            {
                bubbleTimer++;
                var speed = 4f;
                var intensity = 0.2f;

                transform.localPosition = intensity * new Vector3(
                    Mathf.PerlinNoise(speed * Time.time, 1),
                    Mathf.PerlinNoise(speed * Time.time, -1),
                    Mathf.PerlinNoise(speed * Time.time, 3));
            }
        }
    }
}
