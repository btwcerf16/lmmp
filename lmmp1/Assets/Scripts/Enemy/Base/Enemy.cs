using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable, IEnemyMoveable, ITriggerCheckable, ITeamable
{
    
    

    [field: SerializeField] public bool IsFacingRight { get; set; } = true;
    public GameObject floatingDamage;
    [HideInInspector] public Animator animator;

    [Header("States Settings")]

    public float CritChance;


    public bool canRotate;
    public bool canMove;
    
    public bool attackInСooldown;
    public Rigidbody2D rigidBody2D { get; set; }
    public bool isPlayer { get; set; }
    [field: SerializeField] public bool IsAggroed { get; set; }
    [field: SerializeField] public bool IsWithinStrikingDistance { get; set; }

    #region State Machine

    public EnemyStateMachine StateMachine { get; set; }
    public EnemyChaseState ChaseState { get; set; }
    public EnemyAttackState AttackState { get; set; }
    public EnemyIdleState IdleState { get; set; }
    public EnemyDeathState DeathState { get; set; }

    public CharacterBaseStats BaseStats { get; }
    public ActorStats CurrentStats;

    #endregion

    #region Idle variables
    [Header("Idle Settings")]
  
    
    public float waitIdleTime = 0.5f;
    public Transform rightPos;
    public Transform leftPos;
    public Vector3 targetPos;

    #endregion

    #region Chase variables
    //[Header("Chase Settings")]


    #endregion


    private void Awake()
    {
        
        StateMachine = new EnemyStateMachine();

        IdleState = new EnemyIdleState(this, StateMachine);
        ChaseState = new EnemyChaseState(this, StateMachine);
        AttackState = new EnemyAttackState(this, StateMachine);
        DeathState = new EnemyDeathState(this, StateMachine);
    }


    private void Start()
    {
        

        canMove = true;

        animator = GetComponent<Animator>();

        rigidBody2D = GetComponent<Rigidbody2D>();

        

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

    #region Damage/Die/Heal
    public void Damage(float damageAmount)
    {
        CurrentStats.currentHealth -= damageAmount;
        System.Random randomX = new System.Random();
        System.Random randomY = new System.Random();
        float randomPosX = randomX.Next(0, 2);
        float randomPosY = randomY.Next(0, 2);
        Vector2 damagePos = new Vector2(transform.position.x + randomPosX, transform.position.y+ randomPosY);
        Instantiate(floatingDamage, damagePos, Quaternion.identity);
        floatingDamage.GetComponentInChildren<FloatingDamage>().TotalDamage = damageAmount;
        

    }
    public void Heal(float healAmount)
    {
        CurrentStats.currentHealth += healAmount;
    }
    public void Die()
    {
        StateMachine.ChangeState(DeathState);
        
    }
    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
    #endregion

    #region Move functions
    public void MoveEnemy(Vector2 velocity)
    {   
        if (canMove) 
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
        animator.SetBool("IsAttack", true);
    }

   
    #endregion

}
