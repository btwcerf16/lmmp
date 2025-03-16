using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    
    private Vector2 _direction;
    
    private float _currentWaitTime;
    private float speedBuffer = 1.0f; //нужно дл€ остановки у точкиё дабы предотвратить тр€ску
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
        enemy.targetPos = enemy.rightPos.transform.position;
        _currentWaitTime = enemy.waitTime;
        enemy.animator.SetBool("Walk", true);
        
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        if(enemy.IsAggroed)
        {

            enemy.StateMachine.ChangeState(enemy.ChaseState);

        }
        if (Vector2.Distance(enemy.transform.position, enemy.targetPos) < 0.6f && enemy.IsFacingRight)
        {
            if(_currentWaitTime <= 0) 
            {
                enemy.canRotate = false;
                enemy.animator.SetBool("Walk", true);
                enemy.animator.SetBool("Idle", false);
                _currentWaitTime = enemy.waitTime;

                enemy.targetPos = enemy.leftPos.transform.position;
                
                
                Debug.Log("право");
                

            }
            else
            {
                enemy.canRotate = false;
                enemy.StartCoroutine(MoveToNextPos(enemy.waitTime));
                enemy.animator.SetBool("Walk", false);
                enemy.animator.SetBool("Idle", true);
                _currentWaitTime -= Time.deltaTime;
            }
                
        }
        
        if (Vector2.Distance(enemy.transform.position, enemy.targetPos) < 0.6f && !enemy.IsFacingRight)
        {
            if (_currentWaitTime <= 0)
            {
                enemy.animator.SetBool("Walk", true);
                enemy.animator.SetBool("Idle", false);
                _currentWaitTime = enemy.waitTime;
                enemy.targetPos = enemy.rightPos.transform.position;
                
                Debug.Log("Ћево");
            }
            else
            {
                enemy.canRotate = false;
                enemy.StartCoroutine(MoveToNextPos(enemy.waitTime));
                enemy.animator.SetBool("Walk", false);
                enemy.animator.SetBool("Idle", true);
                _currentWaitTime -= Time.deltaTime;
            }
        }
        
        _direction = (enemy.targetPos - enemy.transform.position).normalized;
        enemy.MoveEnemy(_direction * enemy.idleSpeed * speedBuffer);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
    IEnumerator MoveToNextPos(float timeDelay)
    {


        speedBuffer = 0;

        yield return new WaitForSeconds(timeDelay);
        enemy.canRotate = true;
        speedBuffer = 1;
        
    }
}
