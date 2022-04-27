using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    [SerializeField] private float speed; 
    [SerializeField] private float FastSpeed; 
    [SerializeField] private int lives; 
    [SerializeField] private float jump_force;
    private float RealSpeed;
    public LayerMask whatIsGround;
    public Transform GroundCheak;
    private static Hero instance;
    public GameObject Template;
    
    private bool is_ground = false; 
    private bool target1 = false;
    private bool target2 = false;
    private bool target3 = false;

    private Rigidbody2D rigidbody2D;
    private SpriteRenderer sprite;
    public Animator animation;

    //void Awake()
    //{
        //instance = this;
    //}

    private void Start()
    {
        speed = 3f; 
        FastSpeed = 3.1f; 
        lives = 5; 
        jump_force = 8f;
    }

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
            RealSpeed = speed;
            Run();
        }
        if (Input.GetButton("Horizontal") && Input.GetButton("Fire3"))
        {
            RealSpeed = FastSpeed;
            Run();
        }
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        animation.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal") * RealSpeed));
        animation.SetBool("OnGround", is_ground);
        //Mathf.Abs(Input.GetAxis("Horizontal") * speed));
        GameOver();
        
        
    }

    private void Run()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, RealSpeed * Time.deltaTime);
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Target1")
        {
            target1 = true;
        }
        else if (collision.gameObject.tag == "Target2")
        {
            target2 = true;
        }
        else if (collision.gameObject.tag == "Target3")
        {
            target3 = true;
        }
    }

}
