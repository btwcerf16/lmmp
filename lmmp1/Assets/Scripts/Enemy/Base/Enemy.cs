using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable, IEnemyMoveable
{
    [field: SerializeField] public float maxHealth { get; set; }
    [field: SerializeField] public float currentHealth { get; set; }
    public bool IsFacingRight { get; set; } = true;
    public Rigidbody2D rigidBody2D { get; set; }


    #region State Machine

    public EnemyStateMachine StateMachine { get; set; }
    public EnemyChaseState ChaseState { get; set; }
    public EnemyAttackState AttackState { get; set; }
    public EnemyIdleState IdleState { get; set; }

    #endregion

    #region Idle

    public float idleSpeed = 1.0f;
    public float idleRange = 6.0f;

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
        rigidBody2D = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;

        StateMachine.Initialize(IdleState);
    }

    public void Update()
    {
        StateMachine.CurrentEnemyState.FrameUpdate();
    }

    public void FixedUpdate()
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
        rigidBody2D.velocity = velocity;
        CheckRotateOfFace(velocity);
    }

    public void CheckRotateOfFace(Vector2 velocity)
    {
        if (IsFacingRight && velocity.x < 0) {

            Vector2 rotaror = new Vector2(transform.rotation.x, 180.0f);
            transform.rotation = Quaternion.Euler(rotaror);
            IsFacingRight = !IsFacingRight;
        }
        else if (!IsFacingRight && velocity.x > 0)
        {
            Vector2 rotaror = new Vector2(transform.rotation.x, 0.0f);
            transform.rotation = Quaternion.Euler(rotaror);
            IsFacingRight = !IsFacingRight;
        }
        
    }
    #endregion

    private void AnimationTriggerEvent(AnimationTriggerType triggerType) {
    
        StateMachine.CurrentEnemyState.AnimationTriggerEvent(triggerType);

    }

    public enum AnimationTriggerType
    {
        EnemyDamaged
    }
}
