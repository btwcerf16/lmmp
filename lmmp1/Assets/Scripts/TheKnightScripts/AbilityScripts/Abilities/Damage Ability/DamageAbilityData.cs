using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Player/Ability/Create Ability Data", fileName = "DamageAbilityData")]
public class DamageAbilityData : AbilityData
{
    public float damageCount;
    public float attackArea;
    public float BonusDamage;
    public LayerMask targetLayer;
    public override Ability CreateAbility(GameObject owner)
    {
        Ability effect = owner.AddComponent<Ability>();
        effect.Initialize(this);
        return effect;
    }
}
