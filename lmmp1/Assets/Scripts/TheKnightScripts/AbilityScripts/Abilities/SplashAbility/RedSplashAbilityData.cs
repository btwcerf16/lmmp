using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
[CreateAssetMenu(menuName = "Player/Create Ability/RedSlash Ability Data", fileName = "RedSlashAbilityData")]
public class RedSplashAbilityData : AbilityData
{
    public GameObject RedSplashPrefab;

    public override Ability CreateAbility(GameObject owner)
    {
        Ability effect = owner.AddComponent<RedSplashAbility>();
        effect.Initialize(this);
        return effect;
    }

    public override string GetAbilityUpgradeDescription()
    {
        return
        $"<b>{AbilityName}</b>\n" +
       $"{AbilityDescription}\n" +
       $"<color=#9acd32>Улучшение:</color>\n " +
       $"1 level Перезарядка: {AbilityCooldown[0]} Время активации: {AbilityActiveTime[0]} Процент от урона от атак: 50 \n" +
       $"2 level Перезарядка: {AbilityCooldown[1]} Время активации: {AbilityActiveTime[1]} Процент от урона от атак: 50 \n" + 
       $"3 level Перезарядка: {AbilityCooldown[2]} Время активации: {AbilityActiveTime[2]} Процент от урона от атак: 50"
       ;
    }
}