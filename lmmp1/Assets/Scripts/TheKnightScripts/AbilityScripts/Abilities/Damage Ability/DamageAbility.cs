using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Player/Create Ability/Damage Ability")]
public class DamageAbility : Ability
{
    public float damageCount;
    public float attackArea;
    private Player player;

    public override void Activate(GameObject owner)
    {     
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(owner.transform.position, attackArea, targetLayer);
        player = owner.GetComponent<Player>();
        foreach (Collider2D enemy in hitEnemies)
            {
            Buff.Apply(player.currentStats, player);
            if (enemy.GetComponent<IDamageable>() != null)
                {
                    enemy.GetComponent<IDamageable>().Damage((damageCount*player.currentStats.physicDamageMultiplyer));
                }
            }
    }

    public override void BeginCooldown()
    {
        Debug.Log("ֿמסע ִלד:" + (float)(damageCount));
    }
}
