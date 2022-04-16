using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    [SerializeField] private int speed = 0; 
    [SerializeField] private int lives = 5; 
    [SerializeField] private float jump_force = 10f;
    public LayerMask whatIsGround;
    public Transform GroundCheak;
    private static Hero instance;
    public GameObject Template;
    
    private bool is_ground = false; 

    private Rigidbody2D rigidbody2D;
    private SpriteRenderer sprite;
    public Animator animation;

    //void Awake()
    //{
        //instance = this;
    //}

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        instance = this;
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            speed = 3;
            if (Input.GetButtonDown("Fire3"))
                {
                    speed = 5;
                }
            Run();
        }
        else if (Input.GetButtonUp("Horizontal"))
        {
            speed = 0;
        }
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        Debug.Log(speed);
        if (speed == 3)
        {
            animation.SetInteger("Speed", 3);
        }
        if (speed == 5)
        {
            animation.SetInteger("Speed", 5);
        }
        animation.SetInteger("Speed", speed);
        animation.SetBool("OnGround", is_ground);
        //Mathf.Abs(Input.GetAxis("Horizontal") * speed));
        GameOver();
        
        
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
        //Debug.Log(collider.Length);
    }
    private void GameOver()
    {
        if (transform.position.y <= -5)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
            var hero = GetComponent<Hero>();
            hero.enabled = false;
            GameObject gameOverBox = Instantiate(instance.Template);

            Transform panel = gameOverBox.transform.Find("Panel");

            Button RestartLevel = panel.Find("RestartLevel").GetComponent<Button>();

            RestartLevel.onClick.AddListener(() =>
            {
                Destroy(gameOverBox);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            });
        }

    }

}
