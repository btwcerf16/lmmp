using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : ScriptableObject
{
    public string title;
    public string description;
    public Sprite icon;
    public float activeTime;
    public float cooldownTime;
    public LayerMask targetLayer;
    


    public virtual void Activate(GameObject owner)
    {

    }
    public virtual void BeginCooldown()
    {

    }
}
