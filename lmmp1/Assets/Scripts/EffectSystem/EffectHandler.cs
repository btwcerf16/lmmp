using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectHandler : MonoBehaviour
{
    public List<Effect> ActiveEffects = new();

    private void Update()
    {
        for (int i = 0; i < ActiveEffects.Count - 1; i++) {
            //ActiveEffects[i].ApplyEffect();
        }
    }
    public void AddEffect(Effect effect)
    {
        if (ActiveEffects.Contains(effect)) { RemoveEffect(effect); ActiveEffects.Add(effect); }
        else ActiveEffects.Add(effect);
    }
    public void RemoveEffect(Effect effect) 
    { 
        ActiveEffects.Remove(effect);
    }
}
