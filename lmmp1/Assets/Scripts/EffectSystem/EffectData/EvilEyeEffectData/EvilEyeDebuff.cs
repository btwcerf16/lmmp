using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EvilEyeDebuff : Effect
{
    public int HitCounter;


    public float DamagePercent;



    public override void EffectEnd(ActorStats owner)
    {
        if (((EvilEyeEffectData)EffectData).EffectDuration <= 0)
        {
            HitCounter = 0;
        }
    }

    public override void EffectStart(ActorStats owner)
    {
        HitCounter += 1;
        if (HitCounter == ((EvilEyeEffectData)EffectData).HitNeeded)
        {
            owner.currentHealth -= owner.maxHealth / 100.0f * DamagePercent; EffectEnd(owner);
        }

    }

}
