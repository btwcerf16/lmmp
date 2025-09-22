using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(EffectHandler))]
[RequireComponent(typeof(ActorStats))]
public class EffectDisplay : MonoBehaviour
{
    public List<GameObject> EffectSprites;

    public List<Effect> QueueEffects;

    public int busy = 0;
 //&& EffectSprites[1].GetComponent<SpriteRenderer>().sprite != null && EffectSprites[2].GetComponent<SpriteRenderer>().sprite != null
    public void AddEffectSprite(Effect effect)
    {
        if (busy == EffectSprites.Count)
        {
            QueueEffects.Add(effect);
        }
        else
        {
            for (int i = 0; i < EffectSprites.Count; i++)
            {

                if (EffectSprites[i].GetComponent<SpriteRenderer>().sprite == null)
                {
                    EffectSprites[i].GetComponent<SpriteRenderer>().sprite = effect.EffectData.SpriteIcon;
                    busy++;
                    return;
                }
                else { continue; }

            }
        }
    }
    public void ClearEffectSprite(Effect effect)
    {
        for (int i = 0; i < EffectSprites.Count; i++)
        {
            if (EffectSprites[i].GetComponent<SpriteRenderer>().sprite == effect.EffectData.SpriteIcon) {
                EffectSprites[i].GetComponent<SpriteRenderer>().sprite = null;
                busy--;
                if (QueueEffects.Count > 0)
                {
                    AddEffectSprite(QueueEffects[0]);
                    QueueEffects.Remove(QueueEffects[0]);
                }
                
            }
        }
        
    }
    
}
