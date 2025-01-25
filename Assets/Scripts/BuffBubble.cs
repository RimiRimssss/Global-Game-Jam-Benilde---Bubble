using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffBubble : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Bubble>())
        {
            collision.gameObject.transform.localScale += Vector3.one;
            Destroy(this.gameObject);
        }
    }
}
