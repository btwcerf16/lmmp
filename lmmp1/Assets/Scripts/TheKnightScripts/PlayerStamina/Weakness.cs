using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class Weakness : MonoBehaviour
{
    private ActorStats playerActorStats;
    [SerializeField]private SpriteRenderer playerSprite;
    public float DamageDebuff;
    public float CurrentHealthDebuff;
    public float CritChanceDebuff;
    public float CritDamageDebuff;
    public float DamageForDamage;
    [SerializeField]private bool isWeak;
    private int currentStage = 0;
    private float invincibleTimeFrameData;

    private void OnEnable()
    {
        PlayerEventBus.onPlayerAttack += GetStaminaTest;
    }
    private void OnDisable()
    {
        PlayerEventBus.onPlayerAttack -= GetStaminaTest;
    }


    private void Start()
    {
        playerActorStats = GetComponent<ActorStats>();
        playerSprite = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        float s = playerActorStats.ÑurrentStamina; 

        int newStage = 0;
        if (s <= 0 && s > -50)
            newStage = 1;
        else if (s <= -50)
            newStage = 2;

        if (newStage != currentStage)
        {
            UpdateStage(newStage);
        }

        if (isWeak)
        {
            playerSprite.color = new Color32(171,
                (byte)(255 * (playerActorStats.maxStamina + playerActorStats.ÑurrentStamina) / 200),
                (byte)(255 * (playerActorStats.maxStamina + playerActorStats.ÑurrentStamina) / 200), 255);

        }
    }
    private void UpdateStage(int newStage)
    {
        if (currentStage == 1)
            playerActorStats.BonusDamage += DamageDebuff;
        else if (currentStage == 2)
            playerActorStats.BonusDamage += DamageDebuff * 2;

        if (newStage == 1)
        {
            playerActorStats.BonusDamage -= DamageDebuff;
        }
        else if (newStage == 2)
        {
            playerActorStats.BonusDamage -= DamageDebuff * 2;
        }
        currentStage = newStage;
    }

    public void GetStaminaTest()
    {
        if (isWeak)
        {
            playerActorStats.GetComponent<IDamageable>().Damage(DamageForDamage);
        }
       
    }

    public void GetWeakness()
    {
        invincibleTimeFrameData = playerActorStats.invincibleTimeFrame;
        playerActorStats.invincibleTimeFrame = 0;
        playerActorStats.ÑurrentHealth -= CurrentHealthDebuff;
        playerActorStats.critChance -= CritChanceDebuff;
        playerActorStats.critDamage -= CritDamageDebuff;
        isWeak = true;
    }
    public void RemoveWeakness()
    {
        playerActorStats.invincibleTimeFrame = invincibleTimeFrameData;
        playerActorStats.critChance += CritChanceDebuff;
        playerActorStats.critDamage += CritDamageDebuff;
        isWeak = false;
        playerSprite.color = Color.white;
    }
    


}
