using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float scaleFactor = 0.01f;
    [SerializeField] private float moveSpeed = 3.0f;
    [SerializeField] private float bubbleLimit = 3.0f;
    [SerializeField] private float bubbleTimer;
    [SerializeField] private GameObject bubble;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //Expanding Bubble
        if (Input.GetKey(KeyCode.Space) && bubble != null)
        {
            rb2d.gravityScale = -1.0f;
            rb2d.gravityScale += -0.1f;
        }
        else if (Input.GetKey(KeyCode.Space) == false || bubble == null)
        {
            rb2d.gravityScale = 1.0f;
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
