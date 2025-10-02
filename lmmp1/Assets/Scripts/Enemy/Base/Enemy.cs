using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    public ActorStats EnemyCurrentStats;
    public Animator animator;
    public bool IsAgroed;
    public bool TargetWithinCastRadius;
    public bool TargetWithinAttackRadius;
    public Transform TargetTransform;
    

    public virtual void ChaseState() { }
    public virtual void AttackState() { }
    public virtual void PatrolState() { }
    public virtual void DeathState() { }
    public virtual void CastState() { }
    public virtual void MoveEnemy(Vector2 direction)
    {
        
    }
    public virtual void Flip() { }

    public virtual void FindNewTarget()
    {

    }
    #region IDamageable
    public void Damage(float damageAmount)
    {
       EnemyCurrentStats.ÑurrentHealth -= damageAmount;
    }

    public void Die()
    {
        DeathState();
    }

    public void Heal(float healAmount)
    {
        EnemyCurrentStats.ÑurrentHealth += healAmount;
    }
    #endregion

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
