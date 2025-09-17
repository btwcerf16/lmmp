using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    public PatrolByPoints PatrolByPoints;
    public Rigidbody2D rigidBody2D;
   
    

    private void Start()
    {
        PatrolByPoints = GetComponent<PatrolByPoints>();
        rigidBody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        PatrolState();
        
    }

    public override void AttackState()
    {
        base.AttackState();
    }

    public override void CastState()
    {
        base.CastState();
    }

    public override void ChaseState()
    {
        base.ChaseState();
    }

    public override void DeathState()
    {
        base.DeathState();
    }

    public override void PatrolState()
    {
        PatrolByPoints.MoveToPoint();
    }

    public override void MoveEnemy(Vector2 direction)
    {
        rigidBody2D.velocity = direction;
        
    }
    public override void Flip()
    {
        if (rigidBody2D.velocity.x > 0) {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
