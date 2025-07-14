using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringerOfDeath : Enemy, IAttacker
{

    [Header("Attack Settigs")]
    [SerializeField] private float _waitTime;
    [field: SerializeField] public float damage { get; set; }

    [field: SerializeField] public LayerMask enemyLayer { get; set; }
    [field: SerializeField] public Transform attack1point { get; set; }
    [field: SerializeField] public float attackArea { get; set; }

    public Buff AttackDebuff;

    [field: SerializeField] public float attackCooldown { get; set; }
    public float waitTime
    {
        get
        {
            return _waitTime;
        }
        set
        {
            _waitTime = Mathf.Max(0, value);
        }
    }



    public void Attack()
    {
        if (attack1point != null)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attack1point.position, attackArea, enemyLayer);

            CritChance = Random.value;
            foreach (Collider2D enemy in hitEnemies)
            {
                if (enemy.GetComponent<IDamageable>() != null)
                {

                    enemy.GetComponent<IDamageable>().Damage(damage);
                }
                _waitTime = attackCooldown;
                Invoke("Reloading", attackCooldown);
            }
        }
       }
    public void Reloading()
    {

        _waitTime = 0;
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

    public void AttackEffect()
    {
        if (attack1point != null)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attack1point.position, attackArea, enemyLayer);

            CritChance = Random.value;
            foreach (Collider2D enemy in hitEnemies)
            {
                if (enemy.GetComponent<IDamageable>() != null)
                {

                    enemy.GetComponent<IDamageable>().Damage(CurrentStats.attackDamage * CurrentStats.critDamage/100.0f);
                    AttackDebuff.Apply(enemy.GetComponent<ActorStats>(), enemy.GetComponent<MonoBehaviour>());

                }
            }
            _waitTime = attackCooldown;
            Invoke("Reloading", attackCooldown);
        }
    }
}
    





