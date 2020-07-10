using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType{
    NoAttack, Attack
}

public class Enemy : MonoBehaviour
{
    private Player _Player;
    private Animator animator;

    public EnemyType enemyType;

    private bool isAttack;

    private void Start() {
        _Player = FindObjectOfType(typeof(Player)) as Player;
        animator = GetComponent<Animator>();
    }

    private void Update() {

        switch(enemyType)
        {
            case EnemyType.Attack:
            float dist = Vector3.Distance(_Player.transform.position, transform.position);
            if(dist < 2 && !isAttack)
            {
                animator.SetTrigger("attack");
                isAttack = true;
            }
            break;
        }

    }
}
