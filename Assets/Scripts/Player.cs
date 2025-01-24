using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float scaleFactor = 0.01f;
    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private float bubbleLimit = 3.0f;
    [SerializeField] private float bubbleTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Expanding Bubble
        if (Input.GetKey(KeyCode.Space))
        {
            transform.localScale += Vector3.one * scaleFactor;
        }
        else if (Input.GetKey(KeyCode.Space) == false)
        {
            transform.localScale -= Vector3.one * scaleFactor;
            if (transform.localScale.x < 1) transform.localScale = Vector3.one;
        }

        if (transform.localScale.x == bubbleLimit) transform.localScale = Vector3.one;

        if (transform.localScale.x >= bubbleLimit)
        {
            if (bubbleTimer >= 7)
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
