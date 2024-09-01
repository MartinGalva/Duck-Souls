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

    //Climb
    [SerializeField] private float climbSpeed;
    private CapsuleCollider2D cCollider;
    private bool isClimbing;
    float v;
    float initialGravity;
    
   
    void Start ()
    {
        cCollider = GetComponent<CapsuleCollider2D>();
        initialGravity = rb.gravityScale;
    }

    void Update ()
    {
        float h = Input.GetAxis("Horizontal");

        if(h < 0.0f) transform.localScale = new Vector3(-3.0f, 3.0f, 1.0f);
        else if(h > 0.0f) transform.localScale = new Vector3(3.0f, 3.0f, 1.0f);
        
        rb.transform.Translate(new Vector2(h, 0) * Time.deltaTime * speed);
        
        
       /* que solo salte una vez*/ Debug.DrawRay(transform.position, Vector3.down * 0.5f, Color.red);
        if(Physics2D.Raycast(transform.position, Vector3.down, 0.5f)){
            grounded = true;
        } else{
            grounded =  false;
        }
        
        /* fuerza de salto*/if (Input.GetKeyDown(KeyCode.Space) && grounded )
        {
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }

        v = Input.GetAxis("Vertical");

        Climb();      

    }


    public void golpe(){
        vida =  vida -1;
        if(vida == 0) Destroy(gameObject);
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
