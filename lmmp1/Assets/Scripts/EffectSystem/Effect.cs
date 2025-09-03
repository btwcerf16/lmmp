using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Effect : ScriptableObject
{
    public string EffectName;
    public float EffectDuration;
    public float CurrentDuration;
    public string EffectDescription;


    public virtual void EffectSatrt(ActorStats owner) { }
    public virtual void EffectApply(ActorStats owner) { }
    public virtual void EffectEnd(ActorStats owner) { }


}
