using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinText : MonoBehaviour
{
    public static int Coin;
    public static int CountTarget1;
    public static int CountTarget2;
    public static int CountTarget3;
    Text text;
    void Start()
    {
        text = GetComponent<Text>();
        Coin = 0;
        CountTarget1 = 0;
        CountTarget2 = 0;
        CountTarget3 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = Coin.ToString();
    }
}
