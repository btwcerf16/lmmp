using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BleedDebuffEffect : Effect
{
    private float damageAccumulator = 0f;
    private float currentDamageTimer;
    public override void EffectStart(ActorStats owner)
    {
        currentDamageTimer = ((BleedDebuffEffectData)EffectData).DamageTick;
    }
    public override void EffectTick(ActorStats owner)
    {
       float damagePerSecond =
            owner.ÑurrentHealth / 100f
            * ((BleedDebuffEffectData)EffectData).DamagePercent;
       damageAccumulator += damagePerSecond * Time.deltaTime;
       currentDamageTimer -= Time.deltaTime;
       if (currentDamageTimer <= 0f)
       {
            owner.GetComponent<IDamageable>().Damage(damageAccumulator);


            damageAccumulator = 0f;
            currentDamageTimer = ((BleedDebuffEffectData)EffectData).DamageTick;
       }
       TimeRemaining -= Time.deltaTime;
    }

}
