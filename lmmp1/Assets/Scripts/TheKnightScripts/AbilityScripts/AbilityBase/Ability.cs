using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public float TimeRemaining;
    public AbilityData AbilityData;
    public void Initialize(AbilityData _abilityData)
    {
        AbilityData = _abilityData;
        TimeRemaining = _abilityData.AbilityCooldown;
    }
    public virtual void EventTick() { }
    public virtual void ApplyCast() { }
    public virtual void CancelCast() { }
    public virtual void Added() { }

}