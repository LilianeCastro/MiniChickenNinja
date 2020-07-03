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
    public Text textScore;
    public float sizeGround;
    public float scoreToChangeSpeedGame;
    public float speedGame;
    public float increaseSpeed;
    private float currentSpeed;
    private int score;

    [Header("Prefabs")]
    public GameObject[] groundPrefab;
    public GameObject[] platformPrefab;
    public GameObject[] collectablePrefab;
    public GameObject[] weaponPrefab;
    public GameObject[] vFxDestroy;
    public GameObject[] enemyPrefab;

    public SpriteRenderer[] boardToChangeInPlatform;

    void Start() {
        _Ground = FindObjectOfType(typeof(Ground)) as Ground;
        _Menu = FindObjectOfType(typeof(Menu)) as Menu;
        _Sound = FindObjectOfType(typeof(Sound)) as Sound;

        currentSpeed = speedGame;
        isGameplay = true;
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
        textScore.text = $"Score: {score}";
        setSpeed();
        print(currentSpeed);
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


}
