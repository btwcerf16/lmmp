using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    private Player player;
    public Image staminaImage;
    
    private void Awake()
    {
        player = GetComponent<Player>();

    }
    public void Update()
    {
        staminaImage.fillAmount = player.currentStamina / 100.0f;
        
    }
    public void ChangeStaminaAmount(float amount)
    {
        player.currentStamina -= amount;
        staminaImage.fillAmount -= amount/100.0f;
    }
    public void RechargeStaminaAmount()
    {

        player.currentStamina += player.staminaRegeneration; 
        
    }
}
