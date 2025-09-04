using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Character/Effects/Create Crit Buff")]

public class CritBuffEffect : Effect
{
    public float CritBuff;



    public override void EffectEnd(ActorStats owner)
    {
        owner.critChance -= CritBuff;
    }

    public override void EffectSatrt(ActorStats owner)
    {
        owner.critChance += CritBuff;
    }

}
