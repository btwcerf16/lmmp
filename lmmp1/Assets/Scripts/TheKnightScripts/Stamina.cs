using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    private Player player;
    public Image staminaImage;
    public Image weaknessStaminaImage;
    private void Awake()
    {
        player = GetComponent<Player>();

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

        
    }
    public void RechargeStaminaAmount()
    {

        player.currentStats.ÑurrentStamina += player.currentStats.staminaRegeneration * Time.deltaTime;
        staminaImage.fillAmount = (player.currentStats.ÑurrentStamina) / 100.0f;

    }
}
