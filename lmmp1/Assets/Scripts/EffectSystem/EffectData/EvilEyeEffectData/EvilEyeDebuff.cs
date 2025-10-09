using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EvilEyeDebuff : Effect
{
   public int HitCounter;
    private void OnEnable()
    {
        PlayerEventBus.onHealhChanged += ConcoleMessage;
    }
    private void OnDisable()
    {
        PlayerEventBus.onHealhChanged -= ConcoleMessage;
    }
    public override void EffectEnd(ActorStats owner)
    {
        HitCounter = 0;
    }

    public override void EffectTick(ActorStats owner)
    {
        TimeRemaining -= Time.deltaTime;
    }
    public override void EffectStart(ActorStats owner)
    {
        HitCounter += 1;
        if (HitCounter == ((EvilEyeEffectData)EffectData).HitNeeded)
        {
            owner.GetComponent<IDamageable>().Damage(owner.maxHealth / 100.0f * ((EvilEyeEffectData)EffectData).DamagePercent); EffectEnd(owner);
            Debug.Log(HitCounter + " Владелец" + gameObject.name + "Получилось ");

        }
        Debug.Log(HitCounter +" Владелец"+ gameObject.name);

    }
    private void ConcoleMessage()
    {
        Debug.Log("ПОлучил урон");
    }

}
