using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetWithinAttackRadiusCheck : MonoBehaviour
{
    public Enemy enemy;
    private void Start()
    {

        enemy = GetComponentInParent<Enemy>();
    }

    //OnTriggerEnter2D
    //OnTriggerEnter2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (enemy.TargetTransform.gameObject != null&&collision.gameObject == enemy.TargetTransform.gameObject)
        {
            enemy.TargetWithinAttackRadius = true;
           
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (enemy.TargetTransform.gameObject != null && collision.gameObject == enemy.TargetTransform.gameObject)
        {
            
            enemy.TargetWithinAttackRadius = false;

        }
    }
}
