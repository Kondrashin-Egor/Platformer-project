using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MessageBox : MonoBehaviour {

    private static MessageBox instance;
    public GameObject Template;
    [SerializeField] private static Text info;

	// Use this for initialization
	void Awake () {
        instance = this;
    }

    public static void ShowMassage(int action)
    {
        GameObject massageBox = Instantiate(instance.Template);

        Transform panel = massageBox.transform.Find("Panel");

        Text massageBoxText = panel.Find("Text").GetComponent<Text>();

        if (action == 0)
        {
            massageBoxText.text = info.text;
        }

        Button yes = panel.Find("Yes").GetComponent<Button>();

        yes.onClick.AddListener(() =>
        {
            Destroy(massageBox);
            if (action == -1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else if (action == 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        });
    }
}