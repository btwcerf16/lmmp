using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Skeleton : Enemy, IAttacker
{

    [Header("Attack Settigs")]
    [SerializeField] private float _waitTime;
    [field:SerializeField]public float damage { get; set; }

    public LayerMask enemyLayer { get; set; }
    public Transform attack1point { get; set; }
    public float attackArea { get; set; }
    public float coolDown { get; set; }

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
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attack1point.position, attackArea, enemyLayer);


        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.GetComponent<IDamageable>() != null)
            {
                enemy.GetComponent<IDamageable>().Damage(damage);
            }
        }
        waitTime = attackCooldown;
        Invoke("Reloading", attackCooldown);
    }

    public void Reloading()
    {
        waitTime = 0;
    }

    //private void SkeletonAttack()
    //{
    //    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attack1point.position, attackArea, enemyLayer);


    //    foreach (Collider2D enemy in hitEnemies)
    //    {
    //        if (enemy.GetComponent<IDamageable>() != null)
    //        {
    //            enemy.GetComponent<IDamageable>().Damage(5.0f);
    //        }
    //    }
    //    waitTime = coolDown;
    //}


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
