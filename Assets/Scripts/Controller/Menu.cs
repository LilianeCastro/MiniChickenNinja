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

    public GameObject mainMenu;
    public GameObject inGame;
    public GameObject gameOver;
    public GameObject credit;
    public GameObject help;

    public Image spriteRendererNinjaGameOver;

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
        if(nameSceneToLoad.Equals("Menu"))
        {
            _GameController.zeroScore();
            _GameController.fillProgressHUD();
            mainMenu.SetActive(true);
            inGame.SetActive(false);
            gameOver.SetActive(false);
            Destroy(_Persist.gameObject);
        }
        else if(nameSceneToLoad.Equals("GamePlay"))
        {
            _GameController.zeroScore();
            _GameController.fillProgressHUD();
            mainMenu.SetActive(false);
            inGame.SetActive(true);
            gameOver.SetActive(false);
        }
        else if(nameSceneToLoad.Equals("EndGame"))
        {
            spriteRendererNinjaGameOver.sprite = _GameController.playerDeathCurrentSprite[_GameController.getLayerAnimPlayer()].sprite;
            mainMenu.SetActive(false);
            inGame.SetActive(true);
            gameOver.SetActive(true);
        }
        SceneManager.LoadSceneAsync(nameSceneToLoad);
    }

    public void ActivateCredit()
    {
        mainMenu.SetActive(false);
        credit.SetActive(true);
    }

    public void DisableCredit()
    {
        mainMenu.SetActive(true);
        credit.SetActive(false);
    }

    public void ActivateHelp()
    {
        mainMenu.SetActive(false);
        help.SetActive(true);
    }

    public void DisableHelp()
    {
        mainMenu.SetActive(true);
        help.SetActive(false);
    }
}
