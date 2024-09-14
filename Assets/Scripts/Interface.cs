using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interface : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene("SampleScene");
        }
        if (Input.GetKeyDown(KeyCode.P)) {
            pauseGame();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            resumeGame();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            quitGame();
        }
    }

    void pauseGame () {
        Time.timeScale = 0;
    }

    void resumeGame () {
        Time.timeScale = 1;
    }
    void quitGame () {
        Application.Quit();
    }
}
