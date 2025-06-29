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
        if (player.currentStamina <= 0)
        {
            weaknessStaminaImage.fillAmount = (-(player.currentStamina) / 100.0f);
        }
    }
    public void ChangeStaminaAmount(float amount)
    {
            
        player.currentStamina -= amount;
        staminaImage.fillAmount = (player.currentStamina) / 100.0f;
        


        
    }
    public void RechargeStaminaAmount()
    {

        player.currentStamina += player.staminaRegeneration;
        staminaImage.fillAmount = (player.currentStamina) / 100.0f;
    }
}
