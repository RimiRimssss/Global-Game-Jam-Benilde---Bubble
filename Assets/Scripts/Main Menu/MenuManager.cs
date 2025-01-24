using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void GoToGameScene()
    {
        SceneManager.LoadScene("Global Game Jam---Bubble");
    }
}
