using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    public PatrolByPoints PatrolByPoints;
    public Rigidbody2D rigidBody2D;
    public ChaseForward ChaseForward;
    

    private void Start()
    {
        animator = GetComponent<Animator>();
        PatrolByPoints = GetComponent<PatrolByPoints>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        TargetTransform = GameObject.FindGameObjectWithTag("Player").transform;
        ChaseForward = GetComponent<ChaseForward>();
    }
    private void Update()
    {
        //switch (IsAgroed)
        //{
        //    case false:
        //        PatrolState();
        //        break;
        //    case true:
        //        ChaseState(); 
        //        break;
        //}
        if (IsAgroed)
        {
            ChaseState();
        }
        else
        {
            PatrolState();
        }

       

        }

    public override void AttackState()
    {
        
        animator.SetTrigger("Attack");
        MoveEnemy(Vector2.zero);
        
       
    }


     
    public override void ChaseState()
    {
        ChaseForward.ChaseEnemy();
    }

    public override void DeathState()
    {
        animator.SetTrigger("Death");
        MoveEnemy(Vector2.zero);
        gameObject.GetComponent<Enemy>().enabled = false;

    }

    public override void PatrolState()
    {
        PatrolByPoints.MoveToPoint();
    }
    public override void FindNewTarget()
    {
        PatrolByPoints.FindTargetPos();
        Invoke("Flip", 0.1f);
    }

    public override void MoveEnemy(Vector2 direction)
    {
            rigidBody2D.velocity = direction * EnemyCurrentStats.speed;
    }
    public override void Flip()
    {
        if (rigidBody2D.velocity.x > 0) {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
}
