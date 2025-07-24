using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringerOfDeathHandSpell : MonoBehaviour
{
    public Buff Debuff;
    private GameObject playerTarget;
    private void Awake()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == playerTarget)
        
        {
            Debuff.Apply(playerTarget.GetComponent<ActorStats>(), playerTarget.GetComponent<MonoBehaviour>());
        }
            
    }
    private void DestroyOnEnd()
    {
        Destroy(gameObject);
    }

}
