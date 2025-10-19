using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BleedDebuffEffect : Effect
{
   
    public override void EffectTick(ActorStats owner)
    {
        owner.GetComponent<IDamageable>().Damage(owner.ÑurrentHealth/100.0f * ((BleedDebuffEffectData)EffectData).DamagePercent * Time.deltaTime);
        TimeRemaining -= Time.deltaTime;
    }

}
