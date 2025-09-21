using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Effect : ScriptableObject
{
    public string EffectName;
    public float EffectDuration;
    public string EffectDescription;
    public Sprite SpriteIcon;


    public virtual void EffectSatrt(ActorStats owner) { }
    public virtual void EffectApply(ActorStats owner) { }
    public virtual void EffectEnd(ActorStats owner) { }


}
