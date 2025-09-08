
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    

    [SerializeField] private float _currentStamina;
    [SerializeField] private float _currentHealth;

    private HealthBar healthBar;

    public float currentStamina { get => _currentStamina; 
        set => _currentStamina = Mathf.Clamp(value, -100, maxStamina);

    
    }
    public float currentHealth { get => _currentHealth;
        set 
        {
            _currentHealth = Mathf.Min(maxHealth, value);
            if (healthBar != null) { healthBar.ChangeValue(_currentHealth, maxHealth); }
            if(_currentHealth <= 0 && !Dead) {
                Dead = true;
                gameObject.GetComponent<IDamageable>().Die(); }

        }
    }



    public float staminaRegeneration;
    public float critChance;
    public float critDamage;
    public bool Dead;
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
        staminaRegeneration = ConfigStats.BaseStaminaRegeneration;

        healthBar = GetComponent<HealthBar>();
    }

    private void Start()
    {
        currentStamina = maxStamina;
        currentHealth = maxHealth;
    }

}
