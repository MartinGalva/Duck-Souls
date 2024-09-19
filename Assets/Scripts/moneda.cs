using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneda : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            // Destruye la moneda para simular que fue recogida
            Destroy(gameObject);       
        }
    }
}
