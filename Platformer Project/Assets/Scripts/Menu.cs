using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void FirstLocation()
    {
        SceneManager.LoadScene(2);
    }

    public void SecondLocation()
    {
        SceneManager.LoadScene(3);
    }

    public void ThirdLocation()
    {
        SceneManager.LoadScene(4);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Home()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Debug.Log("Game Over");
        Application.Quit();
    }
}
