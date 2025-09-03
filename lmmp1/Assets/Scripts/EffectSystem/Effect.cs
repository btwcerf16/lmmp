using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Effect : ScriptableObject
{
    public string EffectName;
    public string EffectDuration;
    public string EffectDescription;

    public virtual void ApplyEffect(ActorStats owner) { }



}
