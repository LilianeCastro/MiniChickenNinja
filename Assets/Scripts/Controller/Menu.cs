using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private GameController _GameController;
    private Sound _Sound;
    private Persist _Persist;

    public GameObject mainMenu;
    public GameObject inGame;
    public GameObject gameOver;
    public GameObject credit;


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
}
