using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Character/Create Character Base Stats")]

public class CharacterBaseStats : ScriptableObject
{
    public float BaseSpeed;
    public float BaseMaxHealth;
    public float BaseAttackDamage;
    public float BaseMaxStamina;
    public float BaseJumpForce;
    public float BaseMagicResistance;
    public float BasePhysicResistance;
    public float BaseMagicDamageMultiplyer;
    public float BasePhysicDamageMultiplyer;
    public float BaseInvincibleTimeFrame;
    public float BaseCritChanse;
    public float BaseCritDamage;
}
