using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Startmanager : MonoBehaviour
{
    public void PlayButton()
    {
        Debug.Log("play game");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitButton()
    {
        Debug.Log("quit game");
        Application.Quit();
    }

}
