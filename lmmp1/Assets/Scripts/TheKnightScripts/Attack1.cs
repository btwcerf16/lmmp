using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Attack1 : MonoBehaviour, IAttacker
{
    public LayerMask enemyLayer { get; set; }
    public Transform attack1point { get; set; }
    public float attackArea { get; set; }
    public float coolDown { get; set; }
    public float attackCooldown { get; set; }
    private float _waitTime;
    public float waitTime {
        get {
            return _waitTime;
        }
        set {
            _waitTime = Mathf.Max(0, value);
        } 
    }



    private void Update()
    {
        if (waitTime > 0)
        {
            waitTime -= Time.deltaTime;

        }
        
    }
    public void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attack1point.position, attackArea, enemyLayer);
        
        
        foreach(Collider2D enemy in hitEnemies)
        {
            if (enemy.GetComponent<IDamageable>() != null)
            {
                enemy.GetComponent<IDamageable>().Damage(5.0f);
            }
        }
        waitTime = coolDown;
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

    public void Reloading()
    {
        throw new System.NotImplementedException();
    }
}
