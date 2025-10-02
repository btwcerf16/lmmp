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
        if (player.currentStats.�urrentStamina <= 0)
        {
            weaknessStaminaImage.fillAmount = (-(player.currentStats.�urrentStamina) / 100.0f);
            
        }
    }
    public void ChangeStaminaAmount(float amount)
    {
            
        player.currentStats.�urrentStamina -= amount;
        staminaImage.fillAmount = (player.currentStats.�urrentStamina) / 100.0f;

        
    }
    public void RechargeStaminaAmount()
    {

        player.currentStats.�urrentStamina += player.currentStats.staminaRegeneration * Time.deltaTime;
        staminaImage.fillAmount = (player.currentStats.�urrentStamina) / 100.0f;

    }
}
