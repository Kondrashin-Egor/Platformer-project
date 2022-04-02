using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
    private new GameObject gameObject;
    [SerializeField] private int speed = 5;
    // private Transform transform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = transform.right * 1;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        for (int i = 0; i < 126; i++)
        {
            
        }
        //for (int i; i > 0; i--)
        {
            //Vector3 dir = transform.right * 1;
            //transform.position = Vector3.MoveTowards(transform.position, transform.position - dir, speed * Time.deltaTime);
        }
        
    }
}
