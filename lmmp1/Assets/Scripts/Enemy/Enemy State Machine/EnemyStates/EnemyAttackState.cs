using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    public EnemyAttackState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
    }
   
    public override void AnimationTriggerEvent(Enemy.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }
    
    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("Тут атака");
        enemy.SetCanMoveBool(false);

    }

    public override void ExitState()
    {
        base.ExitState();
        
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
       

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        if (enemy.IsWithinStrikingDistance)
        {

            enemy.SetCanMoveBool(false);

            if (enemy.CritChance <= enemy.CurrentStats.critChance / 100.0f)
            {
                enemy.animator.SetTrigger("Attack1");


            }
            else
            {
                enemy.animator.SetTrigger("Attack");

            }

            enemy.animator.SetBool("Walk", false);
            enemy.animator.SetBool("Idle", false);

        }

    }
}
