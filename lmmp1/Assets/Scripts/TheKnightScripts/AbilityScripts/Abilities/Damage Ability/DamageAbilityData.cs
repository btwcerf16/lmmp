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
    public override string GetAbilityUpgradeDescription()
    {
        return
       $"<b>{AbilityName}</b>\n" +
       $"{AbilityDescription}\n" +
       $"<color=#9acd32>Улучшение:</color>\n " +
       $"1 level Перезарядка: {AbilityCooldown[0]} Время активации: {AbilityActiveTime[0]} Урон: {damageCount} Радиус: {attackArea} \n" +
       $"2 level Перезарядка: {AbilityCooldown[1]} Время активации: {AbilityActiveTime[1]} Урон: {damageCount} Радиус: {attackArea} \n" +
       $"3 level Перезарядка: {AbilityCooldown[2]} Время активации: {AbilityActiveTime[2]} Урон: {damageCount} Радиус: {attackArea}"
       ;
    }
}
