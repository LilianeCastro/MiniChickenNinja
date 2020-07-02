using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private GameController _GameController;

    public SpriteRenderer platformSR;
    private Rigidbody2D rg;

    private int idChoose;

    void Start()
    {
        _GameController = FindObjectOfType(typeof(GameController)) as GameController;

        rg = GetComponent<Rigidbody2D>();
        ChangeBoard();
    }

    void Update() {
        if(!_GameController.isGameplayActive())
        {
            rg.velocity = Vector2.zero;
        }

        if(gameObject.transform.position.x < _GameController.sizeGround * -1)
        {
            Destroy(this.gameObject);
        }
    }

    void ChangeBoard()
    {
        idChoose = Random.Range(0,_GameController.boardToChangeInPlatform.Length);
        platformSR.sprite = _GameController.boardToChangeInPlatform[idChoose].sprite;
        if(_GameController.canSpawnAbovePercent(50))
        {
            platformSR.flipX = true;
        }
    }



}
