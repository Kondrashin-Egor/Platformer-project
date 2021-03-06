using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    private new Rigidbody2D rigidbody2D;
    private SpriteRenderer sprite;
    public new Animator animation;

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
        if (Fast.fast)
        {
            if (Input.GetButton("Horizontal") && Input.GetButton("Fire3"))
                {
                    RealSpeed = FastSpeed;
                    Run();
                }
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
            GameObject messageBox = Instantiate(instance.Template);

            Transform panel = messageBox.transform.Find("Panel");

            Button yes = panel.Find("Yes").GetComponent<Button>();

            yes.onClick.AddListener(() =>
            {
                Destroy(messageBox);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            });
        }
    }
}
