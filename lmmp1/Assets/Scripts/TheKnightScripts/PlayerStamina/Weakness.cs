using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weakness : MonoBehaviour
{
    private ActorStats playerActorStats;
    [SerializeField]private SpriteRenderer playerSprite;
    public float DamageDebuff;
    public float CurrentHealthDebuff;
    public float CritChanceDebuff;
    public float CritDamageDebuff;
    [SerializeField]private bool isWeak;


    private void Start()
    {
        playerActorStats = GetComponent<ActorStats>();
        playerSprite = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (isWeak) {
            playerSprite.color = new Color32(171, (byte)(255 * (playerActorStats.maxStamina + playerActorStats.ÑurrentStamina) / 200), (byte)(255 * (playerActorStats.maxStamina + playerActorStats.ÑurrentStamina) / 200), 255);
        }
        
    }

    public void GetWeakness()
    {
        playerActorStats.attackDamage -= DamageDebuff;
        playerActorStats.ÑurrentHealth -= CurrentHealthDebuff;
        playerActorStats.critChance -= CritChanceDebuff;
        playerActorStats.critDamage -= CritDamageDebuff;
        isWeak = true;

    }
    public void RemoveWeakness()
    {
        playerActorStats.attackDamage += DamageDebuff;
        playerActorStats.critChance += CritChanceDebuff;
        playerActorStats.critDamage += CritDamageDebuff;
        playerSprite.color = new Color32(255, 255, 255, 255);
        isWeak = false;
    }


}
