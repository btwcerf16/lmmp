using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityData : ScriptableObject
{
    public string AbilityName;
    [TextArea]public string AbilityDescription;
    public Sprite AbilityIcon;
    public bool HasPassive;
    public KeyCode KeyActivation;
    public int MaxAbilityLevel;
    [Header("Ability Settings")]
    public List<float> AbilityCooldown;
    public List<float> AbilityActiveTime;
    public abstract Ability CreateAbility(GameObject owner);
    public abstract string GetAbilityUpgradeDescription();
}
