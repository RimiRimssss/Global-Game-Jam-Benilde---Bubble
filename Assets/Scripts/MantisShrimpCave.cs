using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MantisShrimpCave : MonoBehaviour
{
   [SerializeField] private Animator anim;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("You gon die buddy");
            StartCoroutine(ImminentMantisDeath(collision.gameObject));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("You live buddy");
            StopCoroutine(ImminentMantisDeath(collision.gameObject));
        }
    }

    IEnumerator ImminentMantisDeath(GameObject deadPlayer)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(2.0f);

        // Disable the player GameObject
        anim.Play("MantisShrimp_Detect");
    }
}
