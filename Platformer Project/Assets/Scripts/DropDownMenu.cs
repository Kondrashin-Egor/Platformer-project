using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownMenu : MonoBehaviour
{
    public Text main;   
    public int rightValue;
    private int lastValue = 0;
    public void InputMenu(int value)
    {
        Debug.Log("LV" + lastValue);
        if (value == rightValue)
        {
            CoinText.CountStars1 ++;
        }
        else
        {
            Debug.Log(CoinText.CountStars1);
            if (CoinText.CountStars1 != 0 && lastValue == rightValue)
            {
                CoinText.CountStars1 --;
            }
        }
        main.text = CoinText.CountStars1.ToString();
        lastValue = value;
    }
}