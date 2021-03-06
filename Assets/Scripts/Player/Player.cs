﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameController _GameController;
    private Rigidbody2D playerRb;
    private Animator playerAnim;

    [Header("Player Config")]
    public float forceJump;
    public Transform weaponPos;
    private float initialPosX;
    private float speedY;
    private int chosenSkinLayer;

    [Header("Ground Config")]
    public Transform groundCheck;
    private bool isGrounded;

    void Start()
    {
        _GameController = FindObjectOfType(typeof(GameController)) as GameController;
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();

        initialPosX = transform.localPosition.x;
        playerAnim.SetLayerWeight(0, 0);

        chosenSkinLayer = Random.Range(0,playerAnim.layerCount);
        playerAnim.SetLayerWeight(chosenSkinLayer, 1);

        _GameController.setLayerAnimPlayer(chosenSkinLayer);
    }

    void FixedUpdate() {
         isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.02f);
    }

    void Update()
    {
        gameObject.transform.localPosition = new Vector3(initialPosX, transform.localPosition.y, transform.localPosition.z);

        if(_GameController.isGameplayActive())
        {
            speedY = playerRb.velocity.y;

            if(Input.GetButtonDown("Jump") && isGrounded)
            {
                _GameController.SetFx(0);
                playerRb.AddForce(new Vector2(0, forceJump));
            }

            if(Input.GetButtonDown("Fire1"))
            {
                if(_GameController.hasKunai())
                {
                    playerAnim.SetTrigger("attack");
                    _GameController.SetFx(4);
                    _GameController.setKunaiProgress(-30);
                    Instantiate(_GameController.weaponPrefab[0], weaponPos.position, weaponPos.rotation);
                }
            }

            if(Input.GetButtonDown("Fire2"))
            {
                if(_GameController.hasBomb())
                {
                    playerAnim.SetTrigger("bomb");
                    _GameController.SetFx(4);
                    _GameController.setBombProgress(-100);
                    Instantiate(_GameController.weaponPrefab[1], weaponPos.position, weaponPos.rotation);
                }
            }

            playerAnim.SetBool("isGrounded", isGrounded);
            playerAnim.SetFloat("speedY", speedY);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        switch(other.gameObject.tag){
            case "collectable":
                _GameController.SetFx(1);
                _GameController.SetScore(1);
                _GameController.setKunaiProgress(10);
                Destroy(other.gameObject);
                break;
            case "collectableDouble":
                _GameController.SetFx(2);
                _GameController.SetScore(1);
                _GameController.setBombProgress(20);
                Destroy(other.gameObject);
                break;
            case "damage":
                _GameController.SetFx(3);
                _GameController.GameOver();
                playerAnim.SetTrigger("death");
                break;
        }
    }

    void Death()
    {
        _GameController.sceneToLoad("EndGame");
    }

}
