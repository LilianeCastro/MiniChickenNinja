using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private Ground _Ground;
    private Menu _Menu;
    private Sound _Sound;

    private string currentScene;
    private bool isGameplay;
    private int layerAnimPlayer;

    [Header("Global Config")]
    public Text textScore;
    public Text textHighScore;
    public Slider kunaiProgress;
    public Slider bombProgress;
    public int valueProgressKunai;
    public int valueProgressBomb;
    public float sizeGround;
    public float scoreToChangeSpeedGame;
    public float speedGame;
    public float increaseSpeed;
    private float currentSpeed;
    private int score;
    private int highScore;

    [Header("Prefabs")]
    public GameObject[] groundPrefab;
    public GameObject[] platformPrefab;
    public GameObject[] collectablePrefab;
    public GameObject[] weaponPrefab;
    public GameObject[] vFxDestroy;
    public GameObject[] enemyPrefab;
    public GameObject[] scoreAnimPrefab;

    public SpriteRenderer[] boardToChangeInPlatform;
    public Image[] playerDeathCurrentSprite;


    void Start() {
        _Ground = FindObjectOfType(typeof(Ground)) as Ground;
        _Menu = FindObjectOfType(typeof(Menu)) as Menu;
        _Sound = FindObjectOfType(typeof(Sound)) as Sound;

        currentSpeed = speedGame;
        isGameplay = true;
        highScore = PlayerPrefs.GetInt("highScore");
        textHighScore.text = "High Score: " + highScore.ToString();
    }

    private void FixedUpdate() {
        kunaiProgress.value += Time.deltaTime;
        bombProgress.value += Time.deltaTime;
    }

    public bool canSpawnAbovePercent(int percent)
    {
        return Random.Range(0, 100) < percent;
    }

    public float getSpeed()
    {
        return currentSpeed;
    }

    private void setSpeed()
    {
        currentSpeed = speedGame + (increaseSpeed * (Mathf.Floor(getScore() / scoreToChangeSpeedGame)));
    }

    public void SetScore(int valuePointsGain)
    {
        score += valuePointsGain;
        textScore.text = $"{score}";
        setSpeed();
    }

    public int getScore()
    {
        return score;
    }

    public int getHighScore()
    {
        return highScore;
    }

    public void updateHighScore()
    {
        if(highScore < score)
        {
            highScore = score;
            PlayerPrefs.SetInt("highScore", score);

            highScore = PlayerPrefs.GetInt("highScore");
            textHighScore.text = "High Score: " + highScore.ToString();
        }

    }
    public void zeroScore()
    {
        score = 0;
        SetScore(score);
    }

    public void fillProgressHUD()
    {
        kunaiProgress.value = valueProgressKunai;
        bombProgress.value = valueProgressBomb;
    }

    public bool hasKunai()
    {
        return kunaiProgress.value > 2;
    }

    public bool hasBomb()
    {
        return bombProgress.value == valueProgressBomb;
    }

    public void setKunaiProgress(int value)
    {
        kunaiProgress.value += value;
    }

    public void setBombProgress(int value)
    {
        bombProgress.value += value;
    }

    public void sceneToLoad(string nameSceneToLoad)
    {
        _Menu.sceneToLoad(nameSceneToLoad);
        setGamePlayActive(true);
    }

    public void GameOver()
    {
        setGamePlayActive(false);
        updateHighScore();
    }

    public bool isGameplayActive()
    {
        return isGameplay;
    }

    public void setGamePlayActive(bool status)
    {
        isGameplay = status;
    }

    public void SetFx(int idFx)
    {
        _Sound.playFx(idFx);
    }

    public void setLayerAnimPlayer(int layerId)
    {
        layerAnimPlayer = layerId;
    }

    public int getLayerAnimPlayer()
    {
        return layerAnimPlayer;
    }
}
