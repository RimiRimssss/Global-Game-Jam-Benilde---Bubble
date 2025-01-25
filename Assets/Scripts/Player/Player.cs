using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Player References
    /// <summary>
    /// where the references will be inserted
    /// </summary>
    [SerializeField] private float moveSpeed = 3.0f;
    [SerializeField] private GameObject bubble;
    private Rigidbody2D rb2d;

    [Header("SFX")]
    public AudioSource playerInhaleAnim;
    public AudioSource playerExhaleAnim;
    public AudioSource playerDeathAnim;
    #endregion

    private bool isInhaling;
    private bool isExhaling;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = this.gameObject.GetComponent<Rigidbody2D>();

        isInhaling = false;
        isExhaling = false;
    }

    #region Player and Bubble Physics Changes

    /// <summary>
    /// Changes that happened to the player and the bubble's physics at a certain time
    /// </summary>
    void FixedUpdate()
    {
        //Expanding Bubble
        if (Input.GetKey(KeyCode.Space) && bubble.gameObject.activeInHierarchy == true)
        {
            if (!isInhaling) // condition that allows the inhale audio to play
            {
                playerInhaleAnim.Play();
                isInhaling = true;
                isExhaling = false;
            }
            rb2d.gravityScale = -bubble.transform.localScale.x / 1.5f;
        }
        else if (!Input.GetKey(KeyCode.Space) || bubble.gameObject.activeInHierarchy == false)
        {
            if (!isExhaling) // condition that allows the exhale audio to play
            {
                playerExhaleAnim.Play();
                isExhaling = true;
                isInhaling = false;
            }
            rb2d.gravityScale = 1.0f;
        }


        // Left and Right movement
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * Time.deltaTime * moveSpeed;
        }
    }
    #endregion

    #region Player Death Condition
    /// <summary>
    /// conditions needed to know to make the player die
    /// </summary>
    /// <param name="collision"></param>
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
    #endregion

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
