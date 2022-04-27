using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class MessageBox : MonoBehaviour {

    private static MessageBox instance;

    public GameObject Template;
    public GameObject GO;
    private Collider2D collision;
    // public GameObject hero;

	// Use this for initialization
	void Awake () {
        instance = this;
        collision = GO.GetComponent(BoxCollider2D);
    }

    public static void ShowMassage(string text)
    {
        // Hero.SetActive(false);
        GameObject massageBox = Instantiate(instance.Template);

        Transform panel = massageBox.transform.Find("Panel");

        Text massageBoxText = panel.Find("Text").GetComponent<Text>();
        massageBoxText.text = text;

        Button yes = panel.Find("Yes").GetComponent<Button>();

        yes.onClick.AddListener(() =>
        {
            //if (GO.gameObject.CompareTag("Target1"))
            {
                if (CoinText.CountTarget1 == 0)
                {
                CoinText.CountTarget1 += 1;
                CoinText.Coin += 1;
                }
            }
            //if (GO.tag == "Target2")
            {
                if (CoinText.CountTarget2 == 0)
                {
                CoinText.CountTarget2 += 1;
                CoinText.Coin += 1;
                }
            }
            //if (GO.tag == "Target3")
            {
                if (CoinText.CountTarget3 == 0)
                {
                CoinText.CountTarget3 += 1;
                CoinText.Coin += 1;
                }
            }
            
            Destroy(massageBox);
        });
    }
}
