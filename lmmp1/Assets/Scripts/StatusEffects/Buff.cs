using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Buff: ScriptableObject    
{
    public Image Image;
    public virtual void Apply(ActorStats stats, MonoBehaviour owner) { }


}
