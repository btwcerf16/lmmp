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
    //    if (player.currentStats.�urrentStamina <= 0)
    //    {
    //        weaknessStaminaImage.fillAmount = (-(player.currentStats.�urrentStamina) / 100.0f);
            

    //    }
    //}
    public void ChangeStaminaAmount(float amount)
    {
            
        player.currentStats.�urrentStamina -= amount;
        PlayerEventBus.onPlayerStaminaChanged?.Invoke(amount);
    }
}
