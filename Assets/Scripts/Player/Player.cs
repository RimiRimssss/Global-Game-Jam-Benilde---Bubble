using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3.0f;
    [SerializeField] private GameObject bubble;
    private Rigidbody2D rb2d;

    [Header("SFX")]
    public AudioSource playerInhaleAnim;
    public AudioSource playerExhaleAnim;
    public AudioSource playerDeathAnim;

    private bool isInhaling;
    private bool isExhaling;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = this.gameObject.GetComponent<Rigidbody2D>();

        isInhaling = false;
        isExhaling = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Expanding Bubble
        if (Input.GetKey(KeyCode.Space) && bubble.gameObject.activeInHierarchy == true)
        {
            if (!isInhaling)
            {
                playerInhaleAnim.Play();
                isInhaling = true;
                isExhaling = false;
            }
            rb2d.gravityScale = -bubble.transform.localScale.x / 1.5f;
        }
        else if (!Input.GetKey(KeyCode.Space) || bubble.gameObject.activeInHierarchy == false)
        {
            if (!isExhaling)
            {
                playerExhaleAnim.Play();
                isExhaling = true;
                isInhaling = false;
            }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
            this.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
            this.gameObject.SetActive(false);
    }

    public void RegainBubble()
    {
        if(bubble.gameObject.activeInHierarchy == false)
        {
            bubble.gameObject.SetActive(true);
        }
    }

    //private void OnDisable()
    //{

    //}
}
