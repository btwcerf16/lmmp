using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    private ActorStats staminaStat;
    [SerializeField] private Weakness weakness;
    public bool IsWeak;

    private void Awake()
    {
        staminaStat = GetComponent<ActorStats>();
        weakness = GetComponent<Weakness>();
    }
    public void ChangeStaminaAmount(float amount)
    {
        staminaStat.ÑurrentStamina += amount;
        PlayerEventBus.onPlayerStaminaChanged?.Invoke(amount);
        if(staminaStat.ÑurrentStamina <= 0 && !IsWeak)
        {
            if (weakness != null)
            {
                weakness.GetWeakness();

            }
           
            IsWeak = true;
        }
        if(staminaStat.ÑurrentStamina > 0 && IsWeak)
        {
            IsWeak = false;
            weakness.RemoveWeakness();
        }
    }
}
