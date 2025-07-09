using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Character/Create Debuff/Bleed Debuff")]

public class BleedDebuff : Buff
{
    public float BleedPercentDamage;
    public float DeadPercent;
    public override void Apply(ActorStats stats, MonoBehaviour owner)
    {
        

        owner.GetComponent<BuffUIHandler>()?.ShowBuff(this);
        owner.StartCoroutine(DurationOfDeBuff(stats, owner));
        
    }
    IEnumerator DurationOfDeBuff(ActorStats stats, MonoBehaviour owner)
    {
        
        float timeRemaining = Duration;
        while (timeRemaining > 0f)
        {
            stats.currentHealth -= (BleedPercentDamage/100.0f)*stats.currentHealth;
            timeRemaining -= 1.0f;
            if(stats.currentHealth <= (DeadPercent/100.0f) * stats.maxHealth) { stats.currentHealth = 0; }
            yield return new WaitForSeconds(1.0f);
        }

           
        owner.GetComponent<BuffUIHandler>().HideBuff(this);
        
        

    }
}
