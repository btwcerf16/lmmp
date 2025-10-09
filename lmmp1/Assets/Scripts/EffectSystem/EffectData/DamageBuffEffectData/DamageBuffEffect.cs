
using UnityEngine;

public class DamageBuffEffect : Effect
{

    public override void EffectEnd(ActorStats owner)
    {
        owner.attackDamage -= ((DamageBuffEffectData)EffectData).DamageBuff;
    }
    public override void EffectTick(ActorStats owner)
    {
        TimeRemaining -= Time.deltaTime;
    }
    public override void EffectStart(ActorStats owner)
    {
        owner.attackDamage += ((DamageBuffEffectData)EffectData).DamageBuff;
    }
}
