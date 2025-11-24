using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Effects/Create Bleed Debuff Data", fileName = " BleedDebuffEffectData")]
public class BleedDebuffEffectData : EffectData
{
    public float DamagePercent;
    public float DamageTick;
    public override Effect CreateEffect(GameObject owner)
    {
        Effect effect = owner.AddComponent<BleedDebuffEffect>();
        effect.Initialize(this);
        return effect;
    }
}
