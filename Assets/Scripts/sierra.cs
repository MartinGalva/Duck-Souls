using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class sierra : MonoBehaviour
{    
    private void OnTriggerEnter2D(Collider2D collision) {
    prueba_1 personaje = collision.GetComponent<prueba_1>();
    sierra cierra = collision.GetComponent<sierra>();

    if (personaje != null) {
        personaje.golpe();
    }

}
    
    
}
