using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    public int nextLevel;
    private void OnTriggerEnter2D(Collider2D collision) {
        prueba_1 personaje = collision.GetComponent<prueba_1>();
        LevelChange casa = collision.GetComponent<LevelChange>();

        SceneManager.LoadScene(nextLevel);   
    }
}
