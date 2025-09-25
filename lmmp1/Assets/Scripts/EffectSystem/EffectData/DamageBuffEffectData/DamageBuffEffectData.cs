using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Effects/Create Damage Buff Data", fileName = " DamageBuffEffectData")]
public class DamageBuffEffectData : EffectData
{
    public float DamageBuff;

    public override Effect CreateEffect(GameObject owner)
    {
        Effect effect = owner.AddComponent<DamageBuffEffect>();
        effect.Initialize(this);
        return effect;
    }
}
