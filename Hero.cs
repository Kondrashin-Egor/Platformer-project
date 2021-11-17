using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private float speed = 5f; 
    [SerializeField] private int lives = 5; 
    [SerializeField] private float jump_force = 10f;
    private bool is_ground = false; 

    private Rigidbody2D rigidbody2D;
    private SpriteRenderer sprite;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            Run();
        }
        if (is_ground && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void Run()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        sprite.flipX = dir.x < 0.0f;
    }

    private void Jump()
    {
        rigidbody2D.AddForce(transform.up * jump_force, ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 1f);
        is_ground = collider.Length > 1;
        if (is_ground)
        {
            Debug.Log("Yes!!!");
        }
        else 
        {
            Debug.Log("No!!!");
        }
    }

}
