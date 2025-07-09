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
    public void Update()
    {
        if (player.currentStats.currentStamina <= 0)
        {
            weaknessStaminaImage.fillAmount = (-(player.currentStats.currentStamina) / 100.0f);
        }
    }
    public void ChangeStaminaAmount(float amount)
    {
            
        player.currentStats.currentStamina -= amount;
        staminaImage.fillAmount = (player.currentStats.currentStamina) / 100.0f;
        


        
    }
    public void RechargeStaminaAmount()
    {

        player.currentStats.currentStamina += player.currentStats.staminaRegeneration * Time.deltaTime;
        staminaImage.fillAmount = (player.currentStats.currentStamina) / 100.0f;
    }
}
