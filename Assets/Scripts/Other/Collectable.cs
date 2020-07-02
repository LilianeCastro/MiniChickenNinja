using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private GameController _GameController;

    private Rigidbody2D rg;
    private Animator animCollectable;


    void Start()
    {
        _GameController = FindObjectOfType(typeof(GameController)) as GameController;

        rg = GetComponent<Rigidbody2D>();
        animCollectable = GetComponent<Animator>();
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

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            animCollectable.SetTrigger("playerPass");
        }
    }
}
