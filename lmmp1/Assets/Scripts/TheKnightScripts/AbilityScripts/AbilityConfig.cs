using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityConfig : ScriptableObject
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public Sprite DisplayImage { get; private set; }
    public float CooldownTime { get; private set; }
    public float CooldownTimer { get; private set; }
    public float ManaCost { get; private set; }
    public KeyCode HotKey { get; private set; }

    public virtual AbilityBuilder GetBuilder() => new AbilityBuilder(this);
}
