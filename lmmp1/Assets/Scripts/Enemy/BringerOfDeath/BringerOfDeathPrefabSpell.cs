using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering;

public class BringerOfDeathPrefabSpell : MonoBehaviour
{
    private BringerOfDeath bringerOfDeath;

    [SerializeField] private Transform spellPoint;
    [SerializeField] private float spellArea;
    [SerializeField] private LayerMask enemyLayer;

    public Effect Debuff;

    private void Start()
    {
        bringerOfDeath = GetComponent<BringerOfDeath>();    
        transform.LookAt(bringerOfDeath.TargetTransform.position);
    }

    private void SpellActivate()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(spellPoint.position, new Vector3(transform.localScale.x / 2.0f, transform.localScale.y * spellArea, transform.localScale.z), enemyLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<IDamageable>().Damage(bringerOfDeath.EnemyCurrentStats.attackDamage 
                * bringerOfDeath.EnemyCurrentStats.magicDamageMultiplyer);
            enemy.GetComponent<EffectHandler>().AddEffect(Debuff);
        }
    }

    private void OnEndDestroy()
    {
        Destroy(gameObject);
    }
    private void OnDrawGizmosSelected()
    {
        if (spellPoint == null)
        {
            return;
        }

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(spellPoint.position,new Vector3(transform.localScale.x * 0.9f, transform.localScale.y*spellArea, transform.localScale.z));
    }


}
