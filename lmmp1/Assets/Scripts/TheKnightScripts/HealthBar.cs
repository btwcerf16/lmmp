using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image HealthBarImage;

    public void ChangeValue(float currentHeath, float maxHealth)
    {
        HealthBarImage.fillAmount = currentHeath / maxHealth;
    }
    
}
