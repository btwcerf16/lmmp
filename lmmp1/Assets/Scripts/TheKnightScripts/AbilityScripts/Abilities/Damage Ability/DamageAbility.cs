using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageAbility : Ability
{
    private Player player;

    public override void EventTick()
    {
        
    }

    public override void ApplyCast()
    {
        base.ApplyCast();
        player = GetComponent<Player>();
        Vector3 spawnPos = new Vector3((player.transform.position.x + 1) * player.transform.localScale.x, player.transform.position.y +1, player.transform.position.z);
        Instantiate(((DamageAbilityData)AbilityData).RoarPrefab,spawnPos ,Quaternion.identity, player.transform);
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, ((DamageAbilityData)AbilityData).AttackArea, 
            ((DamageAbilityData)AbilityData).TargetLayer);
        player = GetComponent<Player>();
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EffectHandler>()?.AddEffect(((DamageAbilityData)AbilityData).WeakEffect);
            //enemy.GetComponent<EffectHandler>()?.Damage(((DamageAbilityData)AbilityData).damageCount * player.currentStats.physicDamageMultiplyer);
            if(CurrentAbilityLevel == 3)
            {
                player.GetComponent<EffectHandler>().AddEffect(((DamageAbilityData)AbilityData).BonusEffect);
            }
        }
    }

    public override void BeginCooldown()
    {
        base.BeginCooldown();
    }

    public override void CancelCast()
    {
        base.CancelCast();
    }

    public override void Added()
    {
        base.Added();
    }



    //public override void Activate(GameObject owner)
    //{     
    //Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(owner.transform.position, attackArea, targetLayer);
    //player = owner.GetComponent<Player>();
    //    foreach (Collider2D enemy in hitEnemies)
    //        {
    //        if (enemy.GetComponent<IDamageable>() != null)
    //            {
    //                enemy.GetComponent<IDamageable>().Damage((damageCount* player.currentStats.physicDamageMultiplyer));
    //            }
    //        }
    //}

    //public override void BeginCooldown(GameObject owner)
    //{
    //    Debug.Log("Ïîñò Äìã:" + (float)(damageCount));
    //}
    //public override void Passive(GameObject owner)
    //{

    //}
}
