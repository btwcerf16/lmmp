using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringerOfDeathHandSpell : MonoBehaviour
{
    public Effect SpellEffect;
    private GameObject playerTarget;
    private void Awake()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == playerTarget)
        
        {
            collision.gameObject.GetComponent<EffectHandler>().AddEffect(SpellEffect);
        }
            
    }
    private void DestroyOnEnd()
    {
        Destroy(gameObject);
    }

}
