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

    [Header("Global Config")]
    public float speedGame;
    public float sizeGround;
    public Text textScore;
    private int score;

    [Header("Prefabs")]
    public GameObject[] groundPrefab;
    public GameObject[] platformPrefab;
    public GameObject[] collectablePrefab;

    public SpriteRenderer[] boardToChangeInPlatform;

    void Start() {
        _Ground = FindObjectOfType(typeof(Ground)) as Ground;
        _Menu = FindObjectOfType(typeof(Menu)) as Menu;
        _Sound = FindObjectOfType(typeof(Sound)) as Sound;

        isGameplay = true;
    }

    public bool canSpawnAbovePercent(int percent)
    {
        return Random.Range(0, 100) < percent;
    }

    public void SetScore(int valuePointsGain)
    {
        score += valuePointsGain;
        textScore.text = $"Score: {score}";
    }

    public int getScore()
    {
        return score;
    }

    public void zeroScore()
    {
        score = 0;
        SetScore(score);
    }

    public void sceneToLoad(string nameSceneToLoad)
    {
        _Menu.sceneToLoad(nameSceneToLoad);
        setGamePlayActive(true);
    }

    public void GameOver()
    {
        isGameplay = false;

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

    public float getSpeed()
    {
        return speedGame;
    }

    public void setSpeed(float newSpeed)
    {
        speedGame = newSpeed;
    }
}
