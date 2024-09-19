using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class sierra : MonoBehaviour
{    
    public float rotationSpeed;
    private void Update () {
        transform.Rotate(0,0,rotationSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        prueba_1 personaje = collision.GetComponent<prueba_1>();
        sierra cierra = collision.GetComponent<sierra>();

        if (personaje != null) {
            personaje.golpe();
        }
    }
}
