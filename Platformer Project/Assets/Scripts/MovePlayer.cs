﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    //Move
    public float speed;
    private float moveInput;
    private Rigidbody2D rb;
    private bool facingRight = true;
    public new Animator animation;


    //Jump
    public float jumpForce;
    private bool isGround;
    public Transform groundchek;
    private int ExtraJump;
    public int extraJumpsValue;
    public float checkRadius;
    public LayerMask whatIsGround;

    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        animation.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal") * speed));
        if (isGround == true)
        {
            Debug.Log("True");
            ExtraJump = extraJumpsValue;
        }


        if (Input.GetKeyDown(KeyCode.Space) && ExtraJump > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            ExtraJump--;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && ExtraJump == 0 && isGround == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void FixedUpdate()
    {
        Debug.Log(isGround);
        isGround = Physics2D.OverlapCircle(groundchek.position, checkRadius, whatIsGround);
        Debug.Log(isGround);
        moveInput = Input.GetAxis("Horizontal");       

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);


        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }

    }

     void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
