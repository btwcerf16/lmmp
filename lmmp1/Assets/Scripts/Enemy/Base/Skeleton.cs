using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    public PatrolByPoints PatrolByPoints;
    public Rigidbody2D rigidBody2D;
    public Vector2 velocity;
    

    private void Start()
    {
        PatrolByPoints = GetComponent<PatrolByPoints>();
        rigidBody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        PatrolState();
        velocity = rigidBody2D.velocity;
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
}
