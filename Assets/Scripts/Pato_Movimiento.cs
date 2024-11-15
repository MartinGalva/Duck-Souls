using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class prueba_1 : MonoBehaviour {
    public int vida = 1;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float JumpForce = 5f;
    [SerializeField] private float speed = 5f;

    //Variables para salto
    private bool grounded;

    private bool alive;

    //Climb
    [SerializeField] private float climbSpeed;
    private CapsuleCollider2D cCollider;
    private bool isClimbing;
    float v;
    float initialGravity;
    
    //Animation
    private Animator animator;

    //Llamar al sound manager
    SoundManager soundManager;

    //Luz
    [SerializeField] public GameObject luz;

    //Projectile
    private bool flippedLeft;
    public bool facingRight;

    

    void Awake()
    {
        soundManager = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();
    }


    void Start ()
    {
        cCollider = GetComponent<CapsuleCollider2D>();
        initialGravity = rb.gravityScale;
        animator = GetComponent<Animator>();
        alive = true;
        facingRight = true;
    }

    void Update ()
    {
        float h = Input.GetAxis("Horizontal");

        if(h < 0.0f) transform.localScale = new Vector3(-3.0f, 3.0f, 1.0f);
        else if(h > 0.0f) transform.localScale = new Vector3(3.0f, 3.0f, 1.0f);
        
        rb.transform.Translate(new Vector2(h, 0) * Time.deltaTime * speed);
        
        animator.SetBool("grounded",grounded);
       /* que solo salte una vez*/ Debug.DrawRay(transform.position, Vector3.down * 0.5f, Color.red);
        if(Physics2D.Raycast(transform.position, Vector3.down, 0.5f)){
            grounded = true;
        } else{
            grounded =  false;
        }

        animator.SetBool("alive", alive);
        
        /* fuerza de salto*/if (Input.GetKeyDown(KeyCode.Space) && grounded )
        {
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }

        v = Input.GetAxis("Vertical");

        Climb();      

        animator.SetFloat("floatX", Mathf.Abs(h)); //Para cambiar a la caminata
        //animator.SetFloat("velocityY", rb.velocity.y);
    }

    void FixedUpdate () {

        float hor = Input.GetAxis("Horizontal");

        if (hor > 0)
        {
            facingRight = true;
            Flip(true);
        }


        if (hor < 0)
        {
            facingRight = false;
            Flip(false);
        }
    }

    public void golpe(){
        vida =  vida -1;
        if(vida == 0) {
           StartCoroutine(playerDeath());
        }    
    }
        
    private void Climb()
    {
        if((v != 0 || isClimbing ) && (cCollider.IsTouchingLayers(LayerMask.GetMask("Stairs"))))
        {
            Vector2 rateOfClimb = new Vector3(rb.velocity.x, v * climbSpeed);
            rb.velocity = rateOfClimb;
            rb.gravityScale = 0;
            isClimbing = true;
        }
        else
        {
            rb.gravityScale = initialGravity;
            isClimbing = false;
        }

        if(grounded)
        {
            isClimbing = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy Weak Point"))
        {
            Destroy(other.transform.parent.gameObject);
        }
        if (other.CompareTag("Enemy") || other.CompareTag("Vacio"))
        {
            StartCoroutine(playerDeath());
        }
    }

    void Flip(bool facingRight)
    {
        if(flippedLeft && facingRight)
        {
            rb.transform.localScale = new Vector3(5,5,1);
            flippedLeft = false;
        }
        if(!flippedLeft && !facingRight)
        {
            rb.transform.localScale = new Vector3(-5,5,1);
            flippedLeft = true;
        }
    }

    IEnumerator playerDeath() {
        alive = false;
        speed = 0;
        JumpForce = 0;
    
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
