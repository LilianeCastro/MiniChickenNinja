using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sound : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip titleSound;
    public AudioClip gameplaySound;
    public AudioClip gameOverSound;

    public AudioClip[] fx;

    public void changeSong(string sceneName)
    {
        if(sceneName.Equals("Menu"))
        {
            audioSource.clip = titleSound;
        }
        else if(sceneName.Equals("GamePlay"))
        {
            audioSource.clip = gameplaySound;
        }
        else
        {
            audioSource.clip = gameOverSound;
        }
        audioSource.Play();
    }

    public void playFx(int idFx)
    {
        if(idFx == 0)
        {
            audioSource.PlayOneShot(fx[0]);
        }
        else if(idFx == 1)
        {
            audioSource.PlayOneShot(fx[1]);
        }
        else if(idFx == 2)
        {
            audioSource.PlayOneShot(fx[2]);
        }
        else
        {
            audioSource.PlayOneShot(fx[3]);
        }

    }
}
