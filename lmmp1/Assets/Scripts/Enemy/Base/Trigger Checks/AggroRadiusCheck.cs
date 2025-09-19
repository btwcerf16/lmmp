using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor.Tilemaps;
using UnityEngine;

public class AggroRadiusCheck : MonoBehaviour
{
    
    public Enemy enemy;
    private void Start()
    {

        enemy = GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == enemy.TargetTransform.gameObject)
        {
            enemy.IsAgroed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == enemy.TargetTransform.gameObject)
        {
            enemy.IsAgroed = false;
            enemy.FindNewTarget();
            
        }
    }
}
