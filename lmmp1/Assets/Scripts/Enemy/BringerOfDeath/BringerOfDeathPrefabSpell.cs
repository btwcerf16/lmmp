using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;

public class BringerOfDeathPrefabSpell : MonoBehaviour
{
    public BringerOfDeath bringerOfDeath;

    

    private DomainDataHandler domainDataHandler;

    public EffectData Debuff;

    private void Awake()
    {
        domainDataHandler = GetComponentInParent<DomainDataHandler>();
        bringerOfDeath = (BringerOfDeath)domainDataHandler.EnemyDomainChildren;
        
        Vector3 Look = transform.InverseTransformPoint(bringerOfDeath.TargetTransform.position);
        float Angle = Mathf.Atan2(Look.y, Look.x) * Mathf.Rad2Deg - 240;

        transform.Rotate(0,0,Angle);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == bringerOfDeath.TargetTransform.gameObject)
        {
            collision.GetComponent<EffectHandler>().AddEffect(Debuff);
        }
    
    
    }

    private void OnEndDestroy()
    {
        Destroy(gameObject);
    }



}
