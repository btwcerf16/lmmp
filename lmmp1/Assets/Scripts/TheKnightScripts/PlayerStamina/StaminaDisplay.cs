using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StaminaDisplay : MonoBehaviour
{

    public Image staminaImage;
    public Image weaknessStaminaImage;



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

        staminaImage.fillAmount = 1;
    }
    private void ChangeStaminaFillAmount(float amount)
    {
        
        if (staminaImage.fillAmount <= 0)
        {
            weaknessStaminaImage.fillAmount += (amount) / 100.0f;


        }
        else
        {
            staminaImage.fillAmount += (amount) / 100.0f;
        }
    }
}
