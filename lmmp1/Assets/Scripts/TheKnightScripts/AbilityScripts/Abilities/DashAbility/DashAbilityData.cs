using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Player/Create Ability/Dash Ability Data", fileName = "DashAbilityData")]
public class DashAbilityData : AbilityData
{
    public List<float> DashTime;
    public List<float> DashPower;
    public override Ability CreateAbility(GameObject owner)
    {
        Ability ability = owner.AddComponent<DashAbility>();
        ability.Initialize(this);
        return ability;
    }
    public override string GetAbilityUpgradeDescription()
    {
        return
       $"{AbilityName}\n" +
       $"{AbilityDescription}\n" +
       $"<color=#9acd32>Улучшение {AbilityName}:</color>\n " +
       $"1 level Перезарядка: {AbilityCooldown[0]} Время активации: {AbilityActiveTime[0]} Продолжительность: {DashTime[0]} Сила дэша: {DashPower[0]} \n" +
       $"2 level Перезарядка: {AbilityCooldown[1]} Время активации: {AbilityActiveTime[1]} Продолжительность: {DashTime[1]} Сила дэша: {DashPower[1]} \n" +
       $"3 level Перезарядка: {AbilityCooldown[2]} Время активации: {AbilityActiveTime[2]} Продолжительность: {DashTime[2]} Сила дэша: {DashPower[2]}"
       ;
    }
}
