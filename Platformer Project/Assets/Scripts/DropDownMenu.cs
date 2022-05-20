using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DropDownMenu : MonoBehaviour
{
    //public Text main
    public int rightValue;

    public static int V1;
    public static int V2;
    public static int V3;
    //public int sceneIndex;
    private int lastValue = 0;
    private int LastLastvalue = 0;

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            StarsControl1.CountStars1 = 0;
        }
        if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            StarsControl1.CountStars2 = 0;
        }
        if (SceneManager.GetActiveScene().buildIndex == 9)
        {
           StarsControl1.CountStars3 = 0;
        }
    }
    public void InputMenu(int value)
    {
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            StarsControl1.CountStars1 += LogicTest1(value, StarsControl1.CountStars1);
            //Debug.Log("First " + CoinText.CountStars1);
        }
        if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            //Debug.Log(LogicTest1(value, CoinText.CountStars2));
            StarsControl1.CountStars2 += LogicTest1(value, StarsControl1.CountStars2);
            //Debug.Log("Second " + StarsControl1.CountStars2);
        }
        if (SceneManager.GetActiveScene().buildIndex == 9)
        {
            StarsControl1.CountStars3 += LogicTest1(value, StarsControl1.CountStars3);
            //Debug.Log("Third " + CoinText.CountStars1);
        }
    }
    private int LogicTest1(int value, int CountStars)
    {
        CountStars = 0;
        if (value == rightValue)
        {
            CountStars ++;
        }
        else
        {
            if (lastValue == rightValue)
            {
                CountStars --;
            }
        }
        //Debug.Log(CountStars);
        lastValue = value;
        LastLastvalue = lastValue;
        return CountStars;
    }
}