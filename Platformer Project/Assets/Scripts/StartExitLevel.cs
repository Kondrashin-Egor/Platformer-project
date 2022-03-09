using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartExitLevel : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D  collision)
    {
        Debug.Log("HJP");
        if (collision.gameObject.tag == "Player" )
        {
            Debug.Log("*****");
            SceneManager.LoadScene(1);
        }
    }
}
