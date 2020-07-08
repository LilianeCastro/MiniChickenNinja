using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private GameController _GameController;
    private Rigidbody2D groundRb;

    [Header("Ground Config")]
    private bool isInstantiate;
    private bool isInstantiatePlatform;
    private int idChosen;

    [Header("Platform Config")]
    public Transform platformAPos;
    public Transform platformChildrenPos;

    [Header("Collectable Config")]
    public Transform[] collectableSpawnPos;


    void Start()
    {
        _GameController = FindObjectOfType(typeof(GameController)) as GameController;
        groundRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        groundRb.velocity = new Vector2(_GameController.getSpeed(), 0);

        if(!_GameController.isGameplayActive())
        {
            groundRb.velocity = Vector2.zero;
        }

        if (gameObject.transform.position.x <= _GameController.sizeGround && groundRb != null && _GameController.isGameplayActive())
        {
            if(gameObject.transform.position.x <= 0 && !isInstantiate)
            {
                isInstantiate = true;

                idChosen = Random.Range(0, _GameController.groundPrefab.Length);
                GameObject temp = Instantiate(_GameController.groundPrefab[idChosen]);
                temp.transform.position = new Vector2(transform.position.x + _GameController.sizeGround, temp.transform.position.y);
            }


            if(gameObject.transform.position.x <= _GameController.sizeGround && !isInstantiatePlatform)
            {
                isInstantiatePlatform = true;

                //85% probability of spawning a collectible on ground
                if (_GameController.canSpawnAbovePercent(85))
                {
                    idChosen = Random.Range(0, _GameController.collectablePrefab.Length);
                    spawnPrefab(_GameController.collectablePrefab[idChosen], collectableSpawnPos[0]);
                }

                //75% probability of appearing the platform
                if (_GameController.canSpawnAbovePercent(75))
                {
                    idChosen = Random.Range(0, _GameController.platformPrefab.Length);
                    spawnPrefab(_GameController.platformPrefab[idChosen], platformAPos);

                    //50% probability of spawning a collectible on platform
                    if (_GameController.canSpawnAbovePercent(50))
                    {
                        idChosen = Random.Range(0, _GameController.collectablePrefab.Length);
                        spawnPrefab(_GameController.collectablePrefab[idChosen], collectableSpawnPos[1]);
                    }

                    //50% probability of the platform appearing if the 1st is spawned
                    if (_GameController.canSpawnAbovePercent(50))
                    {
                        idChosen = Random.Range(0, _GameController.platformPrefab.Length);
                        spawnPrefab( _GameController.platformPrefab[idChosen], platformChildrenPos);

                        //90% probability of spawning a collectible on platform
                        if(_GameController.canSpawnAbovePercent(95))
                        {
                            idChosen = Random.Range(0, _GameController.collectablePrefab.Length);
                            spawnPrefab(_GameController.collectablePrefab[idChosen], collectableSpawnPos[2]);
                        }
                    }
                }
            }
        }

        if (gameObject.transform.position.x < _GameController.sizeGround * -1)
        {
            Destroy(this.gameObject);
        }

    }

    void spawnPrefab(GameObject platform, Transform posSpawn)
    {
        GameObject tempPlatform = Instantiate(platform);
        tempPlatform.transform.parent = posSpawn.transform;
        tempPlatform.transform.localPosition = new Vector2(0, 0);
    }

}
