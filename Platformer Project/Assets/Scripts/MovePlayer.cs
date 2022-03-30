using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MovePlayer : MonoBehaviour
{
    //Move
    public float speed;
    private float moveInput;
    private Rigidbody2D rb;
    public bool facingRight = true;


   //Jump
    public float jumpForce;
    private bool isGround;
    public Transform groundchek;
    private int ExtraJump;
    public int extraJumpsValue;
    public float checkRadius;
    public LayerMask whatIsGround;

    Animator animka;


    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
         animka = GetComponent<Animator>();
    }


    void Update()
    {
        
        if (isGround == true)
        {
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
        isGround = Physics2D.OverlapCircle(groundchek.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");       
        animka.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal") * speed));
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);


    }
}
