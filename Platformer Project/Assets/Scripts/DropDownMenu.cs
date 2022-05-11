using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownMenu : MonoBehaviour
{
    public Text main;   
    public int rightValue;
    public void InputMenu(int value)
    {
        if (value == rightValue)
        {
            Debug.Log(CoinText.Coin);
            CoinText.Coin ++;
        }
        else
        {
            Debug.Log(CoinText.Coin);
            if (CoinText.Coin != 0)
            {
                CoinText.Coin --;
            }
        }
        main.text = CoinText.Coin.ToString();
    }
}