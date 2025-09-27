using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringerOfDeath : Enemy
{
    private PatrolByPoints PatrolByPoints;
    private Rigidbody2D rigidBody2D;
    private ChaseForward ChaseForward;
    [SerializeField] private float handSpellCurrentCooldown;
    [SerializeField] private float handSpellCooldown;
    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
       
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
        PatrolByPoints = GetComponent<PatrolByPoints>();
        
        TargetTransform = GameObject.FindGameObjectWithTag("Player").transform;
        ChaseForward = GetComponent<ChaseForward>();
    }
    private void Update()
    {
    
        if (IsAgroed)
        {
            ChaseState();
            if (TargetWithinAttackRadius && !TargetWithinCastRadius)
            {

                animator.SetBool("Walk", false);
                animator.SetBool("Idle", false);
                AttackState();

            }
            if (TargetWithinCastRadius && handSpellCurrentCooldown == 0)
            {

                animator.SetBool("Walk", false);
                animator.SetBool("Idle", false);
                CastState();
            }
        }
        else
        {
            PatrolState();
            if(handSpellCurrentCooldown > 0) { handSpellCurrentCooldown -= Time.deltaTime; }
            
        }
        


    }
    public override void CastState()
    {
        MoveEnemy(Vector2.zero);
        animator.SetTrigger("Cast");
        Invoke("SetCooldownHandSpell", 1.0f);

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
        if (rigidBody2D.velocity.x > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    private void SetCooldownHandSpell()
    {
        handSpellCurrentCooldown = handSpellCooldown;
    }
}
