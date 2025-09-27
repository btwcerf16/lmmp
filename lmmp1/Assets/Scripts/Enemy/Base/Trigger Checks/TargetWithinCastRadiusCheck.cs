using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetWithinCastRadiusCheck : MonoBehaviour
{
    public Enemy enemy;
    
    private void Start()
    {

        enemy = GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (enemy.TargetTransform.gameObject != null && collision.gameObject == enemy.TargetTransform.gameObject)
        {
            enemy.TargetWithinCastRadius = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (enemy.TargetTransform.gameObject != null && collision.gameObject != null && collision.gameObject == enemy.TargetTransform.gameObject)
        {

            enemy.TargetWithinCastRadius = false;

        }
    }
}
