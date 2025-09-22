using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Character/Effects/Create EvilEye Debuff")]

public class EvilEyeDebuff : Effect
{
    public int HitCounter;
    public int HitNeeded;

    public float DamagePercent;



    public override void EffectEnd(ActorStats owner)
    {
        HitCounter = 0;
    }

    public override void EffectStart(ActorStats owner)
    {
        HitCounter += 1;
        if (HitCounter == HitNeeded)
        {
            owner.currentHealth -= owner.maxHealth / 100.0f * DamagePercent; EffectEnd(owner);
        }
        
    }

}
