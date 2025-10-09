using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    private Player player;

    
    private void Awake()
    {
        player = GetComponent<Player>();
    }
    //public void FixedUpdate()
    //{
    //    if (player.currentStats.ÑurrentStamina <= 0)
    //    {
    //        weaknessStaminaImage.fillAmount = (-(player.currentStats.ÑurrentStamina) / 100.0f);
            

    //    }
    //}
    public void ChangeStaminaAmount(float amount)
    {
            
        player.currentStats.ÑurrentStamina -= amount;
        PlayerEventBus.onPlayerStaminaChanged?.Invoke(amount);
    }
}
