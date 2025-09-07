using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(EffectDisplay))]
[RequireComponent(typeof(ActorStats))]
public class EffectHandler : MonoBehaviour
{
    public ActorStats OwnerActorStats;

    public List<Effect> ActiveEffects = new();

    public EffectDisplay CharacterEffectDisplay;



    private void Start()
    {
        OwnerActorStats = GetComponent<ActorStats>();
    }
    private void Update()
    {
        for (int i = 0; i < ActiveEffects.Count; i++) {
            ActiveEffects[i].EffectApply(OwnerActorStats);
            ActiveEffects[i].CurrentDuration -= Time.deltaTime;
            if(ActiveEffects[i].CurrentDuration <= 0)
            {
                
                ActiveEffects[i].EffectEnd(OwnerActorStats);
                RemoveEffect(ActiveEffects[i]);
            }
        }
    }
    public void AddEffect(Effect effect)
    {
        if (ActiveEffects.Contains(effect)) { RemoveEffect(effect); ActiveEffects.Add(effect); effect.EffectSatrt(OwnerActorStats) ; effect.CurrentDuration = effect.EffectDuration; }
        else ActiveEffects.Add(effect); effect.CurrentDuration = effect.EffectDuration; ;
        CharacterEffectDisplay.AddEffectSprite(effect);
    }
    public void RemoveEffect(Effect effect) 
    { 
        ActiveEffects.Remove(effect);
        CharacterEffectDisplay.ClearEffectSprite(effect);
        CharacterEffectDisplay.QueueEffects.Remove(effect);
    }
    //IEnumerator EffectUpdate(int index)
    //{
        
    //    yield return new WaitForSeconds(1.0f);
    //}
}
