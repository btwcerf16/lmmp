using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Effects/Create Weak Debuff Data", fileName = " WeakDebuffEffectData")]
public class WeakEffectData : EffectData
{
    public float HealthDebuff;
    public float CritDebuff;
    public float DamageDebuff;

    

    public override Effect CreateEffect(GameObject owner)
    {
        Effect effect = owner.AddComponent<WeakDebuff>();
        effect.Initialize(this);
        effectPref = effect;
        return effect;
    }
}
