using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkClouds : MonoBehaviour
{
   
   private void OnTriggerStay2D(Collider2D collision) {
        prueba_1 personaje = collision.GetComponent<prueba_1>();
        DarkClouds nube = collision.GetComponent<DarkClouds>();

        if (personaje != null) {
            personaje.luz.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        prueba_1 personaje = collision.GetComponent<prueba_1>();
        DarkClouds nube = collision.GetComponent<DarkClouds>();

        if (personaje != null) {
            personaje.luz.SetActive(false);
        }
    }
}
