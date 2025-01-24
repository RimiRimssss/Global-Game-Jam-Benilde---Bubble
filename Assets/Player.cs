using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float scaleFactor = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Say ahhh");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) == true)
        {
            transform.localScale += Vector3.one * scaleFactor;
        }
        else if (Input.GetKey(KeyCode.Space) == false)
        {
            transform.localScale -= Vector3.one * scaleFactor;
            //if (transform.localScale != Vector3.one) transform.localScale = Vector3.one;
        }
        
    }
}
