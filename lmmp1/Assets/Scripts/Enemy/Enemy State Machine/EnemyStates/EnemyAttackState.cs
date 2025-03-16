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
        enemy.canMove = false;
        enemy.animator.SetBool("Walk", false);
        enemy.animator.SetBool("Idle", false);
    }

    public override void ExitState()
    {
        base.ExitState();
        enemy.StartCoroutine(CanMoveAgain(1f));
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
<<<<<<< Updated upstream
        
=======
<<<<<<< HEAD
       
            
            enemy.animator.SetTrigger("Attack");
            
         
=======
        
>>>>>>> 6b704074400ac4bcc94aba01855d2432e4c92d9c
>>>>>>> Stashed changes
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        if (enemy.IsWithinStrikingDistance)
        {
            enemy.canMove = false;
            enemy.animator.SetTrigger("Attack");
            enemy.animator.SetBool("Walk", false);
            enemy.animator.SetBool("Idle", false);
            
        }
        
<<<<<<< Updated upstream
=======
    }
    IEnumerator CanMoveAgain(float timeDelay)
    {
        yield return new WaitForSeconds(timeDelay);
        enemy.canMove = true;
>>>>>>> Stashed changes
    }
}
