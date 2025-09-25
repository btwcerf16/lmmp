using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectData : ScriptableObject
{
    public string EffectName;
    public float EffectDuration;
    public string EffectDescription;
    public Sprite SpriteIcon;

    public Effect EffectPrefab;

    public virtual Effect CreateEffect(GameObject target)
    {
        var effect = target.AddComponent(EffectPrefab.GetType()) as Effect;
        effect.Initialize(this);
        return effect;
    }
}
