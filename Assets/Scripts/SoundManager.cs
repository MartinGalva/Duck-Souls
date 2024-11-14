using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    //Variable para mantener el manager entre escenas
    public static SoundManager Instance;
    //El static permite referenciar a la misma clase, en este caso SoundManager
   
    private AudioSource coinSound;

    private void Awake()
    {
        //Código para que la instancia del Sound Manager no se repita por error
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        coinSound = GetComponent<AudioSource>();
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip != null)
        {
            coinSound.PlayOneShot(clip);
        }
    }
}