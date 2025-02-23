using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable, IEnemyMoveable
{
    [field: SerializeField] public float maxHealth { get; set; }
    [field: SerializeField] public float currentHealth { get; set; }
    public bool IsFacingRight { get; set; } = true;
    public Rigidbody2D rigidbody2D { get; set; }


    #region States


    public EnemyStateMachine enemyStateMachine { get; set; }
    public EnemyAttackState enemyAttackState { get; set; }
    public EnemyChaseState enemyChaseState { get; set; }
    public EnemyIdleState enemyIdleState { get; set; }
    #endregion

    #region Idle Variables

    public float randomMofmentRange = 5.0f;
    public float speed = 1.0f;

    #endregion

    private void Awake()
    {
        enemyStateMachine = new EnemyStateMachine();
        enemyIdleState = new EnemyIdleState(this, enemyStateMachine);
        enemyChaseState = new EnemyChaseState(this, enemyStateMachine);
        enemyAttackState = new EnemyAttackState(this, enemyStateMachine);
    }

   
    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;

        enemyStateMachine.Initialize(enemyIdleState);
    }
    private void Update()
    {
        enemyStateMachine.currentEnemyState.FrameUpdate();
    }
    private void FixedUpdate()
    {
        enemyStateMachine.currentEnemyState.PhysicsUpdate();
    }
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

    public enum AnimationTriggerType
    {
        EnemyDamaged
    }
    private void AnimationTriggerEvent(AnimationTriggerType _triggerType) 
    {
        enemyStateMachine.currentEnemyState.AnimationTriggerEvent(_triggerType);
    }
    public void MoveEnemy(Vector2 velocity)
    {
        rigidbody2D.velocity = velocity;
        CheckRotateOfFace(velocity);
    }

    public void CheckRotateOfFace(Vector2 velocity)
    {
        if (IsFacingRight && velocity.x < 0) {

            Vector2 rotaror = new Vector2(transform.rotation.x, 180.0f);
            transform.rotation = Quaternion.Euler(rotaror.x, rotaror.y, 0);
            IsFacingRight = !IsFacingRight;
        }
        else if (!IsFacingRight && velocity.x > 0)
        {
            Vector2 rotaror = new Vector2(transform.rotation.x, 0.0f);
            transform.rotation = Quaternion.Euler(rotaror.x, rotaror.y, 0);
            IsFacingRight = !IsFacingRight;
        }
        
    }
}
