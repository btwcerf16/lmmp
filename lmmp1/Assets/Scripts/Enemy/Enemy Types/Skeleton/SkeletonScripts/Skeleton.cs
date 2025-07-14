using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Skeleton : Enemy, IAttacker
{

    [Header("Attack Settigs")]
    [SerializeField] private float _waitTime;
    [field:SerializeField]public float damage { get; set; }

    [field: SerializeField] public LayerMask enemyLayer { get; set; }
    [field: SerializeField] public Transform attack1point { get; set; }
    [field: SerializeField] public float attackArea { get; set; }

    public Buff AttackDebuff;

    public float attackCooldown { get; set; }
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


            foreach (Collider2D enemy in hitEnemies)
            {
                if (enemy.GetComponent<IDamageable>() != null)
                {

                    enemy.GetComponent<IDamageable>().Damage(damage);
                    AttackDebuff.Apply(enemy.GetComponent<ActorStats>(), enemy.GetComponent<MonoBehaviour>());
                }
            }
            waitTime = attackCooldown;
            Invoke("Reloading", attackCooldown);
        }
    }
 
    public void Reloading()
    {
        waitTime = 0;
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
