using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    private bool isPaused = false; // Booleano para pausar y reanudar con un botón


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }


    public void Pause()
    {
        isPaused = true; // No es necesario ponerlo si no vamos a pausar con botón
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }


    public void Resume()
    {
        isPaused = false; // No es necesario ponerlo si no vamos a pausar con botón
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }


    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void Quit()
    {
        isPaused = false; // No es necesario ponerlo si no vamos a pausar con botón
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
