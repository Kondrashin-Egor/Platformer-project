using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class MessageBox : MonoBehaviour {

    private static MessageBox instance;
    private static MessageBox instance2;
    public GameObject Template;
    public Text t;
    //private static Text info = t;
    

	// Use this for initialization
	void Awake () {
        instance = this;
    }

    public void ShowMassage(string text)
    {
        // Hero.SetActive(false);
        GameObject massageBox = Instantiate(instance.Template);

        Transform panel = massageBox.transform.Find("Panel");

        Text massageBoxText = panel.Find("Text").GetComponent<Text>();
        massageBoxText.text = info.text;

        Button yes = panel.Find("Yes").GetComponent<Button>();

        yes.onClick.AddListener(() =>
        {
            Destroy(massageBox);
        });
    }
}