using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Attack1 : MonoBehaviour
{
    [SerializeField] private LayerMask enemyLayer;
    public Transform attack1point;
    public float attackArea = 0.5f;
    public float coolDown = 0.7f;
    private float _timer;
    public float timer {
        get {
            return _timer;
        }
        set {
            _timer = Mathf.Max(0, value);
        } 
    }


    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;

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
        timer = coolDown;
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
