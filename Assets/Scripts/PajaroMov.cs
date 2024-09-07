using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PajaroMov : MonoBehaviour
{
    
    public GameObject Caca;
    public float speed;
    public float limiteIzquierdo;
    public float limiteDerecho;
    private bool seMueve =  true;

    
    private float tiempoDisparo;

    
    // Start is called before the first frame update
    void Start()
    {
        if(transform.localScale.x > 0) {
            flip();
        }

        
    }

    // Update is called once per frame
    void Update()
    {
       if(seMueve) {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if(transform.position.x >= limiteDerecho) {
            flip();
            seMueve =  false;
        }
       } else {

        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if(transform.position.x <= limiteIzquierdo) {
            flip();
            seMueve =  true;
        }
       }

       
       if(Time.time > tiempoDisparo + 0.20f){
         //shoot();
         tiempoDisparo = Time.time;
         
       }

       
       
    }

    void flip() {

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void shoot() {

        Debug.Log("shoot");

        Vector3 direction = Vector3.down;
        if(transform.localScale.x  < 0f) direction  = Vector3.down;
        else direction = Vector3.down;
        
        GameObject caca = Instantiate(Caca, transform.position, Quaternion.identity);
        caca.GetComponent<cacaScript>().SetDirection(direction);
    }
    }

    
