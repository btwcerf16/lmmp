using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    private Player player;
    public Image staminaImage;
    public Image weaknessStaminaImage;

    public List<EffectData> staminaDebufs;
    private EffectHandler playerEffectHandler;
    private void Awake()
    {
        player = GetComponent<Player>();
        playerEffectHandler = player.GetComponent<EffectHandler>();
    }
    public void FixedUpdate()
    {
        if (player.currentStats.ÑurrentStamina <= 0)
        {
            weaknessStaminaImage.fillAmount = (-(player.currentStats.ÑurrentStamina) / 100.0f);
            

        }
    }
    public void ChangeStaminaAmount(float amount)
    {
            
        player.currentStats.ÑurrentStamina -= amount;
        staminaImage.fillAmount = (player.currentStats.ÑurrentStamina) / 100.0f;
        if (player.currentStats.ÑurrentStamina <= 0 && player.currentStats.ÑurrentStamina > -50) 
        {
            playerEffectHandler.AddEffect(staminaDebufs[0]);
            return;
        }
        else if (player.currentStats.ÑurrentStamina <= -50 && player.currentStats.ÑurrentStamina > -80)
        {
            playerEffectHandler.AddEffect(staminaDebufs[1]);
            playerEffectHandler.RemoveEffect(staminaDebufs[0].effectPref);
            return;
        }
        else if (player.currentStats.ÑurrentStamina <= -80)
        {
            playerEffectHandler.AddEffect(staminaDebufs[2]);
            playerEffectHandler.RemoveEffect(staminaDebufs[1].effectPref);
            return;
        }

    }
    public void RechargeStaminaAmount()
    {

        player.currentStats.ÑurrentStamina += player.currentStats.staminaRegeneration * Time.deltaTime;
        staminaImage.fillAmount = (player.currentStats.ÑurrentStamina) / 100.0f;

    }
}
