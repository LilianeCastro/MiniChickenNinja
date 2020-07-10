using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sound : MonoBehaviour
{
    private GameController _GameController;
    public AudioSource audioSource;

    public AudioClip titleSound;
    public AudioClip gameplaySound;
    public AudioClip gameOverSound;

    public AudioClip[] fx;

    private void Start() {
        _GameController = FindObjectOfType(typeof(GameController)) as GameController;
    }

    public void changeSong(string sceneName)
    {
        if(sceneName.Equals("Menu"))
        {
            audioSource.Stop();
            audioSource.clip = titleSound;
        }
        else if(sceneName.Equals("GamePlay"))
        {
            audioSource.Stop();
            audioSource.clip = gameplaySound;
        }
        else
        {
            audioSource.clip = default;
        }
        audioSource.Play();
    }

    public void playFx(int idFx)
    {
        switch(idFx)
        {
            // Player jump
            case 0:
                audioSource.PlayOneShot(fx[idFx]);
                break;
            // Egg collected
            case 1:
                audioSource.PlayOneShot(fx[idFx]);
                break;
            // Chick collected
            case 2:
                audioSource.PlayOneShot(fx[idFx]);
                break;
            // Player death
            case 3:
                audioSource.PlayOneShot(fx[idFx]);
                break;
            // Kunai hit
            case 4:
                audioSource.PlayOneShot(fx[idFx]);
                break;
            // Bomb explosion
            case 5:
                audioSource.PlayOneShot(fx[idFx]);
                break;
            // Highscore
            case 6:
                audioSource.PlayOneShot(fx[idFx]);
                break;
            // Game Over
            case 7:
                audioSource.PlayOneShot(fx[idFx]);
                break;
            default:
                audioSource.clip = default;
                break;
        }
    }

    public float getAudioSourceVol()
    {
        return audioSource.volume;
    }

    public void setAudioSourceVol(float newVol)
    {
        audioSource.volume = newVol;
    }

}
