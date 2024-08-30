using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prueba_1 : MonoBehaviour {
     public int vida = 1;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float JumpForce = 5f;
    [SerializeField] private float speed = 5f;

    private bool grounded;
   

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
        
        /* fuerza de salto*/if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
    }

    public void golpe(){
        vida =  vida -1;
        if(vida == 0) Destroy(gameObject);
    }

}
