using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public float CooldownTimeRemaining;
    public float ActiveTimeRemaining;
    public AbilityData AbilityData;
    public EAbilityStates State;
    public void Initialize(AbilityData _abilityData)
    {
        AbilityData = _abilityData;
    }
    public virtual void EventTick() { }
    public virtual void ApplyCast() { }
    public virtual void BeginCooldown() { }
    public virtual void CancelCast() { }
    public virtual void Added() { }
    public void SetKeyActivation(KeyCode _keyCode) => AbilityData.KeyActivation = _keyCode;

}