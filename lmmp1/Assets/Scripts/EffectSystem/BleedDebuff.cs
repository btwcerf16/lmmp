using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Character/Effects/Create Bleed buff")]
public class BleedDebuff :Effect
{
    public float DamagePercent;
    public float DiePercent;

    public override void EffectApply(ActorStats owner)
    {
        owner.currentHealth -= owner.currentHealth/100.0f * 5.0f * Time.deltaTime;
        if (owner.currentHealth == owner.maxHealth/100.0f * DiePercent) { owner.currentHealth = owner.maxHealth/100.0f; }
    }
}
