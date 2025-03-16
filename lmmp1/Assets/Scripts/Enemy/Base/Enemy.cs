using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable, IEnemyMoveable, ITriggerCheckable
{
    [field: SerializeField] public float maxHealth { get; set; }
    [field: SerializeField] public float currentHealth { get; set; }

    [field: SerializeField] public bool IsFacingRight { get; set; } = true;
    public Vector2 vel;

    [HideInInspector] public Animator animator;
    public bool canRotate;
    public bool canMove;
    public Rigidbody2D rigidBody2D { get; set; }

    [field: SerializeField] public bool IsAggroed { get; set; }
    [field: SerializeField] public bool IsWithinStrikingDistance { get; set; }

    #region State Machine

    public EnemyStateMachine StateMachine { get; set; }
    public EnemyChaseState ChaseState { get; set; }
    public EnemyAttackState AttackState { get; set; }
    public EnemyIdleState IdleState { get; set; }
    


    #endregion

    #region Idle variables

    public float idleSpeed = 1.0f;
    public float idleRange = 6.0f;
    public float waitTime = 0.5f;
    public Transform rightPos;
    public Transform leftPos;
    public Vector3 targetPos;

    #endregion

    #region Chase variables


    public float chaseSpeed = 2.0f;

    #endregion


    private void Awake()
    {
        StateMachine = new EnemyStateMachine();

        IdleState = new EnemyIdleState(this, StateMachine);
        ChaseState = new EnemyChaseState(this, StateMachine);
        AttackState = new EnemyAttackState(this, StateMachine);
        
    }


    private void Start()
    {
        canMove = true;

        animator = GetComponent<Animator>();

        rigidBody2D = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;

        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        StateMachine.CurrentEnemyState.FrameUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentEnemyState.PhysicsUpdate();
    }

    #region Damage/Die
    public void Damage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0) {
            Die();
        }

    }

    public void Die()
    {
        Debug.Log("Мертв");
    }
    #endregion

    #region Move functions
    public void MoveEnemy(Vector2 velocity)
    {   

        vel = velocity;
<<<<<<< Updated upstream
        if (canMove) 
=======
<<<<<<< HEAD
        if (canMove)
=======
        if (canMove) 
>>>>>>> 6b704074400ac4bcc94aba01855d2432e4c92d9c
>>>>>>> Stashed changes
        {
            rigidBody2D.velocity = velocity;
            CheckRotateOfFace(velocity);
        }
        
    }

    public void CheckRotateOfFace(Vector2 velocity)
    {
        
        if ((IsFacingRight && velocity.x < 0) && canRotate)
        {

            transform.eulerAngles = new Vector3 (0, 180, 0);
            IsFacingRight = !IsFacingRight;
        }
        else if ((!IsFacingRight && velocity.x > 0) && canRotate)
        {

            transform.eulerAngles = new Vector3(0, 0, 0);
            IsFacingRight = !IsFacingRight;
        }


    }
    #endregion

    #region Animation Events
    public enum AnimationTriggerType
    {
        EnemyDamaged
    }
    private void AnimationTriggerEvent(AnimationTriggerType triggerType) {
    
        StateMachine.CurrentEnemyState.AnimationTriggerEvent(triggerType);

    }
    #endregion

    #region Distance Check
    public void SetAggroStatus(bool isAggroed)
    {
        IsAggroed = isAggroed;
    }

    public void SetStrikingDistanceBool(bool isWithinStrikingDistance)
    {
        IsWithinStrikingDistance = isWithinStrikingDistance;
    }
    #endregion

}
