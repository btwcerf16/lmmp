using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetWithinCastRadiusCheck : MonoBehaviour
{
    public Enemy enemy;
    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
         if(collision == enemy.TargetTransform) 
         {
            enemy.TargetWithinCastRadius = true;
        
         }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == enemy.TargetTransform)
        {
            enemy.TargetWithinCastRadius = false;

        }
    }
}
