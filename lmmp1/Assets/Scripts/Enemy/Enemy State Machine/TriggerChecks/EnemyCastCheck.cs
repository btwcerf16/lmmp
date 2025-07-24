using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCastCheck : MonoBehaviour
{
    public GameObject playerTarget { get; set; }
    private Enemy _enemy;
    private void Awake()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player");
        _enemy = GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("каст");
        if (collision.gameObject == playerTarget)
        {
            
            _enemy.SetAggroStatus(false);
            _enemy.SetCanMoveBool(false);
            _enemy.animator.SetBool("Walk", false);
            _enemy.StateMachine.ChangeState(_enemy.CastState);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == playerTarget)
        {

            _enemy.SetAggroStatus(true);
            _enemy.StateMachine.ChangeState(_enemy.ChaseState);
            _enemy.animator.SetBool("Walk", true);

            _enemy.SetCanMoveBool(true);
        }
    }
}
