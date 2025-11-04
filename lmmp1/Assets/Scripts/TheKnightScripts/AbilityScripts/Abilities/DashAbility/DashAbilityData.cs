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
}
