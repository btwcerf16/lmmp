using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Player/Create Ability/Damage Ability Data", fileName = "DamageAbilityData")]
public class DamageAbilityData : AbilityData
{
    public float damageCount;
    public float attackArea;
    public float BonusDamage;
    public LayerMask targetLayer;
    public override Ability CreateAbility(GameObject owner)
    {
        Ability effect = owner.AddComponent<DamageAbility>();
        effect.Initialize(this);
        return effect;
    }
}
