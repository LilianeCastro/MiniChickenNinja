using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType{
    NoAttack, Attack, Shot
}

public class Enemy : MonoBehaviour
{
    private GameController _GameController;
    private Player _Player;
    private Animator animator;

    public EnemyType enemyType;

    private bool isAttack;

    private void Start() {
        _Player = FindObjectOfType(typeof(Player)) as Player;
        _GameController = FindObjectOfType(typeof(GameController)) as GameController;

        animator = GetComponent<Animator>();
    }

    private void Update() {

        switch(enemyType)
        {
            case EnemyType.Attack:

                if(DistanceX() < 2 && DistanceY() < 0.5 && !isAttack)
                {
                    animator.SetTrigger("attack");
                    isAttack = true;
                }
                break;

            case EnemyType.Shot:
                if(DistanceX() < 5 && DistanceY() < 0.5 && !isAttack)
                {
                    animator.SetTrigger("shot");
                    isAttack = true;
                    Instantiate(_GameController.weaponPrefab[2], new Vector2(transform.position.x - 0.15f, transform.position.y + 0.15f), transform.rotation);
                }
                break;
        }

    }

    private float DistanceX()
    {
        return transform.position.x - _Player.transform.position.x;

    }

    private float DistanceY()
    {
        return transform.position.y - _Player.transform.position.y;
    }
}
