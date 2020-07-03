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
        switch(idFx)
        {
            case 0:
                audioSource.PlayOneShot(fx[idFx]);
                break;
            case 1:
                audioSource.PlayOneShot(fx[idFx]);
                break;
            case 2:
                audioSource.PlayOneShot(fx[idFx]);
                break;
            case 3:
                audioSource.PlayOneShot(fx[idFx]);
                break;
            case 4:
                audioSource.PlayOneShot(fx[idFx]);
                break;
            default:
                break;
        }
    }
}
