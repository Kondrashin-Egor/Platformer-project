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

    public static void ShowMassage()
    {
        GameObject massageBox = Instantiate(instance.Template);

        Transform panel = massageBox.transform.Find("Panel");

        Button yes = panel.Find("Понятно").GetComponent<Button>();

        yes.onClick.AddListener(() =>
        {
            Destroy(massageBox);
        });
    }
}
