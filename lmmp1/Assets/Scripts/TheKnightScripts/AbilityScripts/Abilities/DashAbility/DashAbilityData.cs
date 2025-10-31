using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Player/Create Ability/Dash Ability Data", fileName = "DashAbilityData")]
public class DashAbilityData : AbilityData
{
    public float DashTime;
    public float DashPower;
    public override Ability CreateAbility(GameObject owner)
    {
        Ability effect = owner.AddComponent<DashAbility>();
        effect.Initialize(this);
        return effect;
    }
}
