using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
            GameObject messageBox = Instantiate(instance.Template);

            Transform panel = messageBox.transform.Find("Panel");

            Button yes = panel.Find("Yes").GetComponent<Button>();

            yes.onClick.AddListener(() =>
            {
                Destroy(messageBox);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                //CoinText.CountStars2 = 0;
            });
            }
    }
    void Update()
    {
        
    }
}
