using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MessageBox : MonoBehaviour {

    private static MessageBox instance;
    public GameObject Template;
    public Text info;

	// Use this for initialization
	void Awake () {
        instance = this;
    }
    public void ShowMessage()
    {
        GameObject messageBox = Instantiate(instance.Template);

        Transform panel = messageBox.transform.Find("Panel");

        Text messageBoxText = panel.Find("Text").GetComponent<Text>();
        messageBoxText.text = info.text;

        Button yes = panel.Find("Yes").GetComponent<Button>();

        yes.onClick.AddListener(() =>
        {
            Destroy(messageBox);
        });
    }
}