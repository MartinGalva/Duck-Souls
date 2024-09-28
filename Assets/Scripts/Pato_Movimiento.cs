using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            soundManager.PlaySFX(soundManager.jump);
        }

        v = Input.GetAxis("Vertical");

        Climb();      

        animator.SetFloat("floatX", Mathf.Abs(h)); //Para cambiar a la caminata
        //animator.SetFloat("velocityY", rb.velocity.y);
    }


    public void golpe(){
        vida =  vida -1;
        if(vida == 0) {
            alive = false;
            //Destroy(gameObject);
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
}
