using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private float speed = 3f; 
    [SerializeField] private int lives = 5; 
    [SerializeField] private float jump_force = 10f;
    public LayerMask whatIsGround;
    public GameObject GroundCheak;
    private bool is_ground = false; 

    private Rigidbody2D rigidbody2D;
    private SpriteRenderer sprite;
    public Animator animation;

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
        animation.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal") * speed));
        if (Input.GetButton("Horizontal"))
        {
            Run();
        }
        if (Input.GetButtonDown("Jump"))
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
        if (is_ground) 
        {
            rigidbody2D.AddForce(transform.up * jump_force, ForceMode2D.Impulse);
        }
        
    }

    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(GroundCheak.transform.position, 1f, whatIsGround);
        is_ground = collider.Length > 0;
        Debug.Log(collider.Length);
    }
    private void OnCollisionEnter2D(Collision2D  collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            speed = 5f;
        }
    }

}
