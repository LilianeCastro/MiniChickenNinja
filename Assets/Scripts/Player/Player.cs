using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameController _GameController;
    private Rigidbody2D playerRb;
    private Animator playerAnim;

    [Header("Player Config")]
    public float forceJump;
    private float initialPosX;
    private float speedY;

    [Header("Ground Config")]
    public Transform groundCheck;
    private bool isGrounded;

    void Start()
    {
        _GameController = FindObjectOfType(typeof(GameController)) as GameController;
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();

        initialPosX = transform.localPosition.x;
    }

    void FixedUpdate() {
         isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.02f);
    }

    void Update()
    {
        gameObject.transform.localPosition = new Vector3(initialPosX, transform.localPosition.y, transform.localPosition.z);

        speedY = playerRb.velocity.y;

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            _GameController.SetFx(0);
            playerRb.AddForce(new Vector2(0, forceJump));
        }

        playerAnim.SetBool("isGrounded", isGrounded);
        playerAnim.SetFloat("speedY", speedY);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        switch(other.gameObject.tag){
            case "collectable":
                _GameController.SetFx(1);
                _GameController.SetScore(10);
                Destroy(other.gameObject, 0.5f);
                break;
            case "collectableDouble":
                _GameController.SetFx(2);
                _GameController.SetScore(20);
                Destroy(other.gameObject, 0.5f);
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
        _GameController.sceneToLoad("gameOver");
    }

}
