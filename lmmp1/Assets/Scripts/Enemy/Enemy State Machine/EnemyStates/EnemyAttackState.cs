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
        Debug.Log("��� �����");
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        if (enemy.IsWithinStrikingDistance)
        {
            enemy.canMove = false;
            enemy.animator.SetBool("Attack", true);
            enemy.animator.SetBool("Walk", false);
            enemy.animator.SetBool("Idle", false);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        
        
    }
}
