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
       $"{AbilityName}\n" +
       $"{AbilityDescription}\n" +
       $"<color=#9acd32>Улучшение {AbilityName}:</color>\n " +
       $"Урон от атаки: 50%\n"+
       $"Дополнительный множитель без усталости: 60%\n" +
       $"Перезарядка: {AbilityCooldown[0]}/{AbilityCooldown[1]}/{AbilityCooldown[2]}\n" +
       $"Время активации: {AbilityActiveTime[0]}/{AbilityActiveTime[1]}/{AbilityActiveTime[2]}\n"
       ;
    }
}