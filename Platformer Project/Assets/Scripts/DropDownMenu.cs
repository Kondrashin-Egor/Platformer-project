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
            CoinText.Coin ++;
        }
        else
        {
            Debug.Log(CoinText.Coin);
            if (CoinText.Coin != 0 && lastValue == rightValue)
            {
                CoinText.Coin --;
            }
        }
        main.text = CoinText.Coin.ToString();
        lastValue = value;
    }
}