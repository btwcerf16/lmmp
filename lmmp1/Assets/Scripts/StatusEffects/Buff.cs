using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Buff: ScriptableObject    
{
    public Sprite Icon;
    public float Duration;

    public virtual void Apply(ActorStats stats, MonoBehaviour owner) { }
   

}
