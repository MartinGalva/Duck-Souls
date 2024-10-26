using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private GameObject pointA;
    [SerializeField] private GameObject pointB;
    private Rigidbody2D rb;
    private Transform currentPoint;
    [SerializeField] private float speed;
    public float limiteIzquierdo;
    public float limiteDerecho;
    //public float distanciaIzquierda;
    //public float distanciaDerecha;
    private bool seMueve =  true;

    //Chase
    [SerializeField] private Transform playerTransform;
    private bool isChasing;
    [SerializeField] private float chaseDistance;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //currentPoint = pointB.transform;
        //limiteIzquierdo = transform.position.x - distanciaIzquierda;
        //limiteDerecho = transform.position.x + distanciaDerecha;
         transform.position = new Vector3(limiteIzquierdo, transform.position.y, transform.position.z);

        /*if(transform.localScale.x > 0) {
            Flip();
        }*/
    }

    void Update()
    {
        



        //patrullaje solo anda bien
        /*if(seMueve) {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if(transform.position.x >= limiteDerecho) {
            Flip();
            seMueve =  false;
        }
       } else {

        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if(transform.position.x <= limiteIzquierdo) {
            Flip();
            seMueve =  true;
        }
       }*/

       //Chase
        if (isChasing)
        {
            
            if (transform.position.x > playerTransform.position.x)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);  
            }
            else if (transform.position.x < playerTransform.position.x)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);  
            }
        }
        else
        {
            
            if (seMueve)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                if (transform.position.x >= limiteDerecho)
                {
                    Flip();
                    seMueve = false;  
                }
            }
            else
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                if (transform.position.x <= limiteIzquierdo)
                {
                    Flip();
                    seMueve = true;  
                }
            }

            
            if (Vector2.Distance(transform.position, playerTransform.position) < chaseDistance)
            {
                isChasing = true;
            }
        }


      
       
        
    }



    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }



    

}