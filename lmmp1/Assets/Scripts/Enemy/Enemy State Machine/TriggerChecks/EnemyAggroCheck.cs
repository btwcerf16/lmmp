using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggroCheck : MonoBehaviour
{
    public GameObject playerTarget {  get; set; }
    private Enemy _enemy;
    private void Awake()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player");
        _enemy = GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == playerTarget) 
        {

            _enemy.SetAggroStatus(true);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == playerTarget)
        {
            
            _enemy.SetAggroStatus(false);
            _enemy.StateMachine.ChangeState(_enemy.IdleState);
            if (Vector2.Distance(_enemy.transform.position, _enemy.rightPos.position) < Vector2.Distance(_enemy.transform.position, _enemy.leftPos.position))
            {
                _enemy.targetPos = _enemy.leftPos.position;
                Debug.Log("Левая точка");
            }
            if (Vector2.Distance(_enemy.transform.position, _enemy.leftPos.position) < Vector2.Distance(_enemy.transform.position, _enemy.rightPos.position))
            {
                
                _enemy.targetPos = _enemy.rightPos.position;
                Debug.Log("Правая точка");
            }
            
            
            
        }
    }
}
