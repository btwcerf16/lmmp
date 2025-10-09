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
        for (int i = 0; i < ActiveEffects.Count; i++)
        {

            ActiveEffects[i].EffectTick(OwnerActorStats);
            
            if (ActiveEffects[i].TimeRemaining <= 0 && ActiveEffects[i].TimeRemaining >=-5)
            {

                ActiveEffects[i].EffectEnd(OwnerActorStats);
                RemoveEffect(ActiveEffects[i]);
            }
        }
    }
    public void AddEffect(EffectData effectData)
    {
        //if (ActiveEffects.Contains(effectData))
        //{

        //    RemoveEffect(effectData);
        //    ActiveEffects.Add(effectData);

        //    effectData.EffectPrefab.EffectStart(OwnerActorStats);

        //}
        //else
        //{
        //    ActiveEffects.Add(effectData);
        //}

        //CharacterEffectDisplay.AddEffectSprite(effectData);
        
        Effect existing = ActiveEffects.Find(effect => effect.EffectData == effectData);
        if (existing != null)
        {
            existing.TimeRemaining = effectData.EffectDuration;
            existing.EffectStart(OwnerActorStats);
            return;

        }
        else
        {
            Effect newEffect = effectData.CreateEffect(gameObject);
            ActiveEffects.Add(newEffect);
            newEffect.EffectStart(OwnerActorStats);
            CharacterEffectDisplay.AddEffectSprite(newEffect);
        }
        
        
        }

    //IEnumerator EffectUpdate(int index)
    //{

    //    yield return new WaitForSeconds(1.0f);
    //}
    public void RemoveEffect(Effect effect)
    {
        

        ActiveEffects.Remove(effect);

        CharacterEffectDisplay.ClearEffectSprite(effect);
        CharacterEffectDisplay.QueueEffects.Remove(effect);
        Destroy(effect);
    }
}
   

