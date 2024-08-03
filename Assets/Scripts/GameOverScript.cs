using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverScript : MonoBehaviour
{
    public bool GameOver = false;
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void RestartGame()
    {
        Debug.Log("Restart");
        SceneManager.LoadScene(1);
    }
    public void MainMenu()
    {
        Debug.Log("main menu");
        SceneManager.LoadScene(0);
    }
}
