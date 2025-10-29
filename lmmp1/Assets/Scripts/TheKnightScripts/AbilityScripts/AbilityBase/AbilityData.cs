using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityData : ScriptableObject
{
    public string AbilityName;
    public float AbilityCooldown;
    public float AbilityActiveTime;
    public string AbilityDescription;
    public Sprite AbilityIcon;
    public bool HasPassive;
    public KeyCode KeyActivation;

    public abstract Ability CreateAbility(GameObject owner);
}
