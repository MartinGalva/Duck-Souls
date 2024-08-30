using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class sierra : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    

    private void OnTriggerEnter2D(Collider2D collision) {
    prueba_1 personaje = collision.GetComponent<prueba_1>();
    sierra cierra = collision.GetComponent<sierra>();

    if (personaje != null) {
        personaje.golpe();
    }

}
    
    
}
