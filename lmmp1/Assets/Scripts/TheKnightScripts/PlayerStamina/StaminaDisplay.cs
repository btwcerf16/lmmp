using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StaminaDisplay : MonoBehaviour
{

    public Image staminaImage;
    public Image weaknessStaminaImage;
    private ActorStats staminaStat;

    private void Start()
    {
        staminaStat = GetComponent<ActorStats>();
        staminaImage.fillAmount = 1;
    }
    private void Update()
    {
        if (staminaStat.�urrentStamina <= 0)
        {
            weaknessStaminaImage.fillAmount = -staminaStat.�urrentStamina / 100.0f;
            
        }
        else
        {
            staminaImage.fillAmount = staminaStat.�urrentStamina / 100.0f;
        }
    }
}
