using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
    Button button;

    private void Start()
    {
        button = GameObject.Find("Button").GetComponent<Button>();

        button.onClick.AddListener(() => {
            MessageBox.ShowMassage();
        });
    }
}
