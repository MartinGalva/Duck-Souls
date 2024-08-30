using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class cacaScript : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D Rigidbody2D;
    private  Vector2 Direction;
    // Start is called before the first frame update
    void Start()
    {
       Rigidbody2D = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate() {

        Rigidbody2D.velocity = Direction * Speed;

        
    }

    public void SetDirection(Vector2 direction) {

        Direction = direction;
    }

    public void destroyCaca(){

        Destroy(gameObject);
    }

    // Update is called once per frame
    
}
