using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static bool ExText1;
    public static bool ExText2;
    public static bool ExText3;
    public void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void FirstLocation()
    {
        SceneManager.LoadScene(4);
    }

    public void SecondLocation()
    {
        SceneManager.LoadScene(6);
    }

    public void ThirdLocation()
    {
        SceneManager.LoadScene(8);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Home()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitTest1()
    {
        //ExText1 = true;
        SceneManager.LoadScene(1);
    }

    public void ExitTest2()
    {
        //ExText2 = true;
        SceneManager.LoadScene(2);
    }

    public void ExitTest3()
    {
        //ExText3 = true;
        SceneManager.LoadScene(3);
    }

    public void ExitGame()
    {
        Debug.Log("Game Over");
        Application.Quit();
    }
}

