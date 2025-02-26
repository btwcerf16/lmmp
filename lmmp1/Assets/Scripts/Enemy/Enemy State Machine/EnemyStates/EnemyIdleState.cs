using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    private Vector3 _targetPos;
    private Vector3 _direction;
    public EnemyIdleState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
    }

    public override void AnimationTriggerEvent(Enemy.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();
        _targetPos = GetRandomPos();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        _direction = (_targetPos- enemy.transform.position).normalized;

        enemy.MoveEnemy(_direction * enemy.idleSpeed);
        if ((enemy.transform.position - _targetPos).sqrMagnitude > 0.01f) ;
        {
            _targetPos = GetRandomPos() ;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
    private Vector3 GetRandomPos()
    {
        return enemy.transform.position + (Vector3)UnityEngine.Random.insideUnitCircle * enemy.idleSpeed;
    }
}
