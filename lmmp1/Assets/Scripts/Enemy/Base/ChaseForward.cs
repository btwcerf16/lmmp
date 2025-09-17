using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseForward : MonoBehaviour
{
    private Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        
    }

    public void ChaseEnemy()
    {
        if (enemy.TargetTransform != null && enemy.EnemyCurrentStats.canMove)
        {
            Vector2 moveDirection = (enemy.TargetTransform.position - enemy.transform.position).normalized;
            if (enemy.EnemyCurrentStats.canMove) { enemy.animator.SetBool("Walk", true); enemy.MoveEnemy(moveDirection * enemy.EnemyCurrentStats.speed ); }

        }
        if (enemy.TargetWithinAttackRadius) {
            
            enemy.animator.SetBool("Walk", false);
            enemy.animator.SetBool("Idle", false);
            enemy.AttackState();
            
        }
        
    }
}
