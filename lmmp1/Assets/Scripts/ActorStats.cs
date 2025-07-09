using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorStats : MonoBehaviour
{
    public CharacterBaseStats ConfigStats;

    public float speed;
    public float maxHealth;
    public float attackDamage;
    public float maxStamina;
    public float jumpForce;
    public float magicResistance;
    public float physicResistance;
    public float magicDamageMultiplyer;
    public float physicDamageMultiplyer;
    public float invincibleTimeFrame;
    public float currentStamina;
    public float staminaRegeneration;
    public float currentHealth;
    public float critChance;
    public float critDamage;
    private void Awake()
    {
        speed = ConfigStats.BaseSpeed;
        maxHealth = ConfigStats.BaseMaxHealth;
        attackDamage = ConfigStats.BaseAttackDamage;
        maxStamina = ConfigStats.BaseMaxStamina;
        jumpForce = ConfigStats.BaseJumpForce;
        magicResistance = ConfigStats.BaseMagicResistance;
        physicResistance = ConfigStats.BasePhysicResistance;
        magicDamageMultiplyer = ConfigStats.BaseMagicDamageMultiplyer;
        physicDamageMultiplyer = ConfigStats.BasePhysicDamageMultiplyer;
        invincibleTimeFrame = ConfigStats.BaseInvincibleTimeFrame;
        critChance = ConfigStats.BaseCritChanse;
        critDamage = ConfigStats.BaseCritDamage;

    }

    private void Start()
    {
        currentStamina = maxStamina;
        currentHealth = maxHealth;
    }

}
