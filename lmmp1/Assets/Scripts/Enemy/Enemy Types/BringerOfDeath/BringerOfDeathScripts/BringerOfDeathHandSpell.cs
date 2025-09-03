using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringerOfDeathHandSpell : MonoBehaviour
{
    
    private GameObject playerTarget;
    private void Awake()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == playerTarget)
        
        {
            
        }
            
    }
    private void DestroyOnEnd()
    {
        Destroy(gameObject);
    }

}
