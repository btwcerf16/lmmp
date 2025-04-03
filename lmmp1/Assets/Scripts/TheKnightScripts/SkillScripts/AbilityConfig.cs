using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityConfig : ScriptableObject
{
    public string title { get; private set; }
    public string description { get; private set; }
    public Sprite displayImage { get; private set; }
    public float cooldownTime { get; private set; }
    public float manaCost { get; private set; }
    public KeyCode HotKey { get; private set; }
    public virtual AbilityBuilder GetBuilder() => new AbilityBuilder(this);
}
