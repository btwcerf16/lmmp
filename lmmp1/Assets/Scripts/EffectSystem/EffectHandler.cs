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
    public List<float> EffectsTimer = new();


    public EffectDisplay CharacterEffectDisplay;



    private void Start()
    {
        OwnerActorStats = GetComponent<ActorStats>();
    }
    private void Update()
    {
        for (int i = 0; i < ActiveEffects.Count; i++)
        {

            ActiveEffects[i].EffectApply(OwnerActorStats);
            EffectsTimer[i] -= Time.deltaTime;
            if (EffectsTimer[i] <= 0)
            {

                ActiveEffects[i].EffectEnd(OwnerActorStats);
                RemoveEffect(ActiveEffects[i]);
            }
        }
    }
    public void AddEffect(Effect effect)
    {
        if (ActiveEffects.Contains(effect))
        {
            int timerIndex = EffectsTimer.IndexOf(EffectsTimer[ActiveEffects.IndexOf(effect)]);
            RemoveEffect(effect);
            ActiveEffects.Add(effect);
            EffectsTimer.Add(effect.EffectDuration);
            effect.EffectSatrt(OwnerActorStats);
            EffectsTimer[timerIndex] = effect.EffectDuration;
        }
        else
        {
            EffectsTimer.Add(effect.EffectDuration);
           
            ActiveEffects.Add(effect);
        }
        
        CharacterEffectDisplay.AddEffectSprite(effect);
    }
    public void RemoveEffect(Effect effect)
    {
        
        EffectsTimer.Remove(EffectsTimer[ActiveEffects.IndexOf(effect)]);
        ActiveEffects.Remove(effect);
        
        CharacterEffectDisplay.ClearEffectSprite(effect);
        CharacterEffectDisplay.QueueEffects.Remove(effect);
    }
    //IEnumerator EffectUpdate(int index)
    //{

    //    yield return new WaitForSeconds(1.0f);
    //}
}