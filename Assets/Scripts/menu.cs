using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    
    public void Jugar()
    {
        SceneManager.LoadScene(SceneManager. GetActiveScene().buildIndex +1);
    }
    public void Salir(  )
    {
        Debug.Log("Salir");
        Application.Quit();
    }
    public void Jugar2()
    {
        SceneManager.LoadScene(SceneManager. GetActiveScene().buildIndex +2);
    }
    public void Jugar3()
    {
        SceneManager.LoadScene(SceneManager. GetActiveScene().buildIndex +3);
    }

}
