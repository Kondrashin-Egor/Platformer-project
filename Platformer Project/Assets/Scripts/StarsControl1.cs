using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarsControl1 : MonoBehaviour
{
    public GameObject star1, star2, star3, star4;
    public GameObject button;
    public static int CountStars1;
    public static int CountStars2;
    public static int CountStars3;

    void Start()
    {
        button.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
        star4.SetActive(false);
        star1.SetActive(true);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            ChekCountStars(CountStars1);
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            ChekCountStars(CountStars2);
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            ChekCountStars(CountStars3);
        }

        // Debug.Log(CoinText.CountStars1);
        
    }
    private void ChekCountStars(int CountStars)
    {
        if(CountStars == 1)
        {
            star1.SetActive(false);
            star3.SetActive(false);
            star4.SetActive(false);
            star2.SetActive(true);
            if (SceneManager.GetActiveScene().buildIndex != 3)
            {
                button.SetActive(true);
            }
        }
        else if (CountStars == 2)
        {
            star1.SetActive(false);
            star2.SetActive(false);
            star4.SetActive(false);
            star3.SetActive(true);
            if (SceneManager.GetActiveScene().buildIndex != 3)
            {
                button.SetActive(true);
            }
        }

        else if (CountStars == 3)
        {
            star1.SetActive(false);
            star2.SetActive(false);
            star3.SetActive(false);
            star4.SetActive(true);
            if (SceneManager.GetActiveScene().buildIndex != 3)
            {
                button.SetActive(true);
            }
        }
        else
        {
            star2.SetActive(false);
            star3.SetActive(false);
            star4.SetActive(false);
            star1.SetActive(true);
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                button.SetActive(false);
            }
        }
}
}

