using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    private Vector3z _targetPos;
    private Vector2 _direction;
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

        _direction = (_targetPos- enemy.transform.position);

        enemy.MoveEnemy(_direction * enemy.idleSpeed * Time.deltaTime);
        if ((enemy.transform.position - _targetPos).sqrMagnitude < 0.1f);
        {
            _targetPos = GetRandomPos() ;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
    private Vector2 GetRandomPos()
    {
        return enemy.transform.position + (Vector3)UnityEngine.Random.insideUnitCircle * enemy.idleSpeed;
    }
}
