using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Character/Effects/Create Damage Buff")]

public class DamageBuffEffect : Effect
{
    public float DamageBuff;

    
    
    public override void EffectEnd(ActorStats owner)
    {
        owner.attackDamage -= DamageBuff;
    }

    public override void EffectSatrt(ActorStats owner)
    {
        owner.attackDamage += DamageBuff;
    }
}
