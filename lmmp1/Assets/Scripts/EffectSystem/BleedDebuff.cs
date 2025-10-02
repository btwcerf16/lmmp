using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Character/Effects/Create Bleed buff")]
public class BleedDebuff :Effect
{
    public float DamagePercent;
    public float DiePercent;

    public override void EffectTick(ActorStats owner)
    {
        owner.ÑurrentHealth -= owner.ÑurrentHealth/100.0f * DamagePercent * Time.deltaTime;
        
           
    }
}
