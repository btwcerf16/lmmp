using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EffectDisplay : MonoBehaviour
{
    public List<GameObject> EffectSprites;

    public List<Effect> QueueEffects;
 //&& EffectSprites[1].GetComponent<SpriteRenderer>().sprite != null && EffectSprites[2].GetComponent<SpriteRenderer>().sprite != null
    public void AddEffectSprite(Effect effect)
    {
        if (EffectSprites[0].GetComponent<SpriteRenderer>().sprite != null)
        {
            QueueEffects.Add(effect);
        }
        for (int i = 0; i < EffectSprites.Count; i++) 
        {
            
            if (EffectSprites[i].GetComponent<SpriteRenderer>().sprite == null)
            {
                EffectSprites[i].GetComponent<SpriteRenderer>().sprite = effect.SpriteIcon;
                return;
            }
            else { continue; }
            
        }
    }
    public void ClearEffectSprite(Effect effect)
    {
        for (int i = 0; i < EffectSprites.Count; i++)
        {
            if (EffectSprites[i].GetComponent<SpriteRenderer>().sprite == effect.SpriteIcon) {
                EffectSprites[i].GetComponent<SpriteRenderer>().sprite = null;
                
            }
        }
        if (QueueEffects != null)
        {
            AddEffectSprite(effect);
            QueueEffects.Remove(effect);
        }
    }
    
}
