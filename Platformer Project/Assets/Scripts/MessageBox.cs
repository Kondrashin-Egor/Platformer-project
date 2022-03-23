using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class MessageBox : MonoBehaviour {

    private static MessageBox instance;

    public GameObject Template;

	// Use this for initialization
	void Awake () {
        instance = this;
    }

    public static void ShowMassage(string text)
    {
        GameObject massageBox = Instantiate(instance.Template);

        Transform panel = massageBox.transform.Find("Panel");

        Text massageBoxText = panel.Find("Text").GetComponent<Text>();
        massageBoxText.text = text;

        Button yes = panel.Find("Yes").GetComponent<Button>();

        yes.onClick.AddListener(() =>
        {
            Destroy(massageBox);
        });
    }
}
