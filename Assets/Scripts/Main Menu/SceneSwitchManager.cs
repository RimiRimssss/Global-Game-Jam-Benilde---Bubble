using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchManager : MonoBehaviour
{
    void Awake()
    {
        Time.timeScale = 1f;
    }

    #region Button Functions
    /// <summary>
    /// List of button functions available in the game
    /// </summary>
    public void SwitchScenes(int indexScene)
    {
        SceneManager.LoadSceneAsync(indexScene); // opens the scene depending on the number of scene in build settings scene index
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    #endregion
}
