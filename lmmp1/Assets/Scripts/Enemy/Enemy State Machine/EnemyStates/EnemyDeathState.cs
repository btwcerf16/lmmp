using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathState : EnemyState
{
    public EnemyDeathState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
    }

    public override void AnimationTriggerEvent(Enemy.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.animator.SetTrigger("Death");
        enemy.BodyCollider2D.enabled = false;
        enemy.CurrentStats.enabled = false;
        enemy.SetCanMoveBool(false);
    }

    public override void ExitState()
    {
        base.ExitState();
        enemy.SetCanMoveBool(false);
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
