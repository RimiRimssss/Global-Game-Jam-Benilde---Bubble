using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatTrigger : MonoBehaviour
{
    public GameManager gameManager; // Reference to the GameManager

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player has entered the trigger
        if (other.CompareTag("Player"))
        {
            gameManager.ShowLosePanel();
        }
    }
}
