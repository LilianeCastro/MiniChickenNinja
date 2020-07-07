using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Menu : MonoBehaviour
{
    private GameController _GameController;
    private Sound _Sound;
    private Persist _Persist;

    [Header("Panel Scene Config")]
    public GameObject mainMenu;
    public GameObject inGame;
    public GameObject gameOver;

    public Image[] spriteRendererCanvas;

    void Start() {
        _GameController = FindObjectOfType(typeof(GameController)) as GameController;
        _Sound = FindObjectOfType(typeof(Sound)) as Sound;
        _Persist = FindObjectOfType(typeof(Persist)) as Persist;
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void sceneToLoad(string nameSceneToLoad)
    {
        _Sound.changeSong(nameSceneToLoad);

        switch(nameSceneToLoad)
        {
            case "Menu":
                Destroy(_Persist.gameObject);
                _GameController.zeroScore();
                _GameController.fillProgressHUD();
                _GameController.getAudioSourceVol();
                mainMenu.SetActive(true);
                inGame.SetActive(false);
                gameOver.SetActive(false);

                break;
            case "GamePlay":
                _GameController.zeroScore();
                _GameController.fillProgressHUD();
                mainMenu.SetActive(false);
                inGame.SetActive(true);
                gameOver.SetActive(false);
                break;
            case "EndGame":
                spriteRendererCanvas[0].sprite = _GameController.playerDeathCurrentSprite[_GameController.getLayerAnimPlayer()].sprite;
                mainMenu.SetActive(false);
                inGame.SetActive(true);
                gameOver.SetActive(true);
                break;
        }

        SceneManager.LoadSceneAsync(nameSceneToLoad);
    }

    public void ActivateSettings()
    {
        currentImgSound();
        StartCoroutine("settingsConfig");
    }

    public void DisableSettings()
    {
        _GameController.setAudioSourceVol(_Sound.getAudioSourceVol());
        StopCoroutine("settingsConfig");
    }

    IEnumerator settingsConfig()
    {
        yield return new WaitForSeconds(0.1f);

        currentImgSound();
        _Sound.setAudioSourceVol(_GameController.getAudioSourceVol());
        StartCoroutine("settingsConfig");
    }

    void currentImgSound()
    {
        if(_Sound.getAudioSourceVol() > 0)
        {
            spriteRendererCanvas[1].sprite = spriteRendererCanvas[2].sprite;
        }
        else
        {
            spriteRendererCanvas[1].sprite = spriteRendererCanvas[3].sprite;
        }
    }

    public void clearHighScore()
    {
        _GameController.clearHighScore();
    }


}
