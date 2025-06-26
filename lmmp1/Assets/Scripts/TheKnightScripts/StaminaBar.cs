using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    private Player player;
    public Image staminaImage;
    private void Awake()
    {
        player = GetComponentInParent<Player>();

    }
    public void Update()
    {
        staminaImage.fillAmount = player.Stamina / 100.0f;
    }
}
