using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class Portals : MonoBehaviour
{
    private static Portals instance;

    public GameObject Template;
    // public GameObject hero;
    
    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SetActive(false);
            
            GameObject endBox = Instantiate(instance.Template);

            Transform panel = endBox.transform.Find("Panel");

            Button yes = panel.Find("Yes").GetComponent<Button>();

            yes.onClick.AddListener(() =>
            {
                Destroy(endBox);
                SceneManager.LoadScene(1);
            });
        }
    }
}
