using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{

    private Vector3 _targetPos;
    private Vector3 _direction;
    public EnemyIdleState(Enemy _enemy, EnemyStateMachine _enemyStateMachine) : base(_enemy, _enemyStateMachine)
    {
    }

    public override void AnimationTriggerEvent(Enemy.AnimationTriggerType _triggerType)
    {
        base.AnimationTriggerEvent(_triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();

        _targetPos = GetRandomPointOnGround();
    }

   

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        _direction = (_targetPos - enemy.transform.position).normalized;
        enemy.MoveEnemy(_direction * enemy.speed);

        if ((enemy.transform.position - _targetPos).sqrMagnitude < 0.01f)
        {
            _targetPos = GetRandomPointOnGround();
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }


    private Vector3 GetRandomPointOnGround()
    {
        return enemy.transform.position + (Vector3)UnityEngine.Random.insideUnitCircle * enemy.randomMofmentRange; 
            }
}
