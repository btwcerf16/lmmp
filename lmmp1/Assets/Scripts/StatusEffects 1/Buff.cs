using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Buff : ScriptableObject, IBuff
{
    public void Apply(ActorStats stats, MonoBehaviour owner) { }

}
