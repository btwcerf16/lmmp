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
}