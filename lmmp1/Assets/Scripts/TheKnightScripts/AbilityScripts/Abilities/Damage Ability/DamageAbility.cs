using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Player/Create Ability/Damage Ability")]
public class DamageAbility : Ability
{
    private Player player;

    public override void EventTick()
    {
        
    }

    public override void ApplyCast()
    {
        base.ApplyCast();
        Debug.Log("Used");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, ((DamageAbilityData)AbilityData).attackArea, ((DamageAbilityData)AbilityData).targetLayer);
        player = GetComponent<Player>();
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<IDamageable>()?.Damage(((DamageAbilityData)AbilityData).damageCount * player.currentStats.physicDamageMultiplyer);
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
    //    Debug.Log("ֿמסע ִלד:" + (float)(damageCount));
    //}
    //public override void Passive(GameObject owner)
    //{

    //}
}
