using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    public ActorStats EnemyCurrentStats;

    public virtual void ChaseState() { }
    public virtual void AttackState() { }
    public virtual void PatrolState() { }
    public virtual void DeathState() { }
    public virtual void CastState() { }
    public virtual void MoveEnemy(Vector2 direction)
    {

    }

    #region IDamageable
    public void Damage(float damageAmount)
    {
       EnemyCurrentStats.currentHealth -= damageAmount;
    }

    public void Die()
    {
        
    }

    public void Heal(float healAmount)
    {
        EnemyCurrentStats.currentHealth += healAmount;
    }
    #endregion
}
