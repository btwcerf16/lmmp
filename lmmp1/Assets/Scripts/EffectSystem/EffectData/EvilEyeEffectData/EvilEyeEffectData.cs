using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Effects/Create EvilEye Debuff Data", fileName = "EvilEyeDebuffEffectData")]
public class EvilEyeEffectData : EffectData
{
    public float HitNeeded;

    public override Effect CreateEffect(GameObject owner)
    {
        Effect effect = owner.AddComponent<EvilEyeDebuff>();
        effect.Initialize(this);
        return effect;
    }
}
