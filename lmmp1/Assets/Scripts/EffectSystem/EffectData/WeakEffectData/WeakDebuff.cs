using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakDebuff : Effect
{


    public override void EffectStart(ActorStats owner)
    {
        owner.maxHealth -= ((WeakEffectData)EffectData).HealthDebuff;
        owner.attackDamage -= ((WeakEffectData)EffectData).DamageDebuff ;
        owner.critDamage -= ((WeakEffectData)EffectData).CritDebuff;
    }
    public override void EffectEnd(ActorStats owner)
    {
        owner.maxHealth -= ((WeakEffectData)EffectData).HealthDebuff;
        owner.attackDamage -= ((WeakEffectData)EffectData).DamageDebuff;
        owner.critDamage -= ((WeakEffectData)EffectData).CritDebuff;
    }
}
