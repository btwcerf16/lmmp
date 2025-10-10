using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StaminaDisplay : MonoBehaviour
{

    public Image staminaImage;
    public Image weaknessStaminaImage;
    private ActorStats staminaStat;
    

    private void OnEnable()
    {
        PlayerEventBus.onPlayerStaminaChanged += ChangeStaminaFillAmount;
    }
    private void OnDisable()
    {
        PlayerEventBus.onPlayerStaminaChanged -= ChangeStaminaFillAmount;
    }

    private void Start()
    {
        staminaStat = GetComponent<ActorStats>();
        staminaImage.fillAmount = 1;
    }
    private void ChangeStaminaFillAmount(float amount)
    {
        
        if (staminaStat.ÑurrentStamina <= 0)
        {
            weaknessStaminaImage.fillAmount = -staminaStat.ÑurrentStamina / 100.0f;
            
        }
        else
        {
            staminaImage.fillAmount = staminaStat.ÑurrentStamina / 100.0f;
        }
    }
}
