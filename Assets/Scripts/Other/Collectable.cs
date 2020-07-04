using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private GameController _GameController;

    private Rigidbody2D rg;


    void Start()
    {
        _GameController = FindObjectOfType(typeof(GameController)) as GameController;
    }

    void Update()
    {
        if(gameObject.transform.position.x < _GameController.sizeGround * -1)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            if(this.gameObject.tag.Equals("collectable"))
            {
                Destroy(Instantiate(_GameController.scoreAnimPrefab[0], new Vector2(other.transform.position.x, other.transform.position.y + 0.5f) , transform.rotation), 0.5f);
            }
            if(this.gameObject.tag.Equals("collectableDouble"))
            {
                Destroy(Instantiate(_GameController.scoreAnimPrefab[1], new Vector2(other.transform.position.x, other.transform.position.y + 0.5f), transform.rotation), 0.5f);
            }
        }
    }
}
