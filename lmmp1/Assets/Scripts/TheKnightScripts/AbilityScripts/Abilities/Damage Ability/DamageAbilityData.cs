using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Player/Create Ability/Damage Ability Data", fileName = "DamageAbilityData")]
public class DamageAbilityData : AbilityData
{
    public float damageCount;
    public float attackArea;
    public EffectData BonusEffect;
    public LayerMask targetLayer;
    public override Ability CreateAbility(GameObject owner)
    {
        Ability effect = owner.AddComponent<DamageAbility>();
        effect.Initialize(this);
        return effect;
    }
    public override string GetAbilityUpgradeDescription()
    {
        return
       $"{AbilityName}\n" +
       $"{AbilityDescription}\n" +
       $"<color=#9acd32>Улучшение {AbilityName}:</color>\n" +
       $"Радиус: {attackArea}\n"+
       $"Урон: {damageCount}\n"+
       $"Перезарядка: {AbilityCooldown[0]}/{AbilityCooldown[1]}/{AbilityCooldown[2]}\n" +
       $"Время активации: {AbilityActiveTime[0]}/{AbilityActiveTime[1]}/{AbilityActiveTime[2]}\n"
       ;
    }
}
