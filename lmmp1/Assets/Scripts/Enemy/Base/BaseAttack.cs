using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAttack : MonoBehaviour, IAttacker
{
    [field: SerializeField] public LayerMask enemyLayer { get; set; }
    [field: SerializeField] public Transform attack1point { get; set; }
    [field: SerializeField] public float attackArea { get; set; }
   
    [field:SerializeField] public ActorStats actorStats { get; set; }

    public EffectData effect;

    private void Start()
    {
        actorStats = GetComponent<ActorStats>();    
    }

    public void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attack1point.position, attackArea, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<IDamageable>()?.Damage(actorStats.attackDamage + actorStats.BonusDamage);
            enemy.GetComponent<EffectHandler>()?.AddEffect(effect);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attack1point == null)
        {
            return;
        }

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attack1point.position, attackArea);
    }
}
