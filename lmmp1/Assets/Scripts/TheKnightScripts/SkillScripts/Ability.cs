using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Ability
{
    public event Action<float, float> EventChangeCooldownTimer;
    public string title { get;private set; }
    public string description { get; private set; }
    public Sprite displayImage { get; private set; }
    public float cooldownTime {  get; private set; }
    public float cooldownTimer { get; private set; }
    public float manaCost { get; private set; }
    public KeyCode HotKey { get; private set; }
    public EAbilityEnum status { get; private set; }
    public void SetDescriprion(string abilityTitle, string abilityDescription, Sprite abilityDisplayImage)
    {
        title = abilityTitle;
        description = abilityDescription;
        displayImage = abilityDisplayImage;   

    }
    public void SetKey(KeyCode key) => HotKey = key;
    
    public float SetCooldownTime(float abilityCooldownTime) => cooldownTime = abilityCooldownTime;

    public void SetManaCost(float abilityManaCost) => manaCost = abilityManaCost;

    public void ChangeStatus(EAbilityEnum abilityStatus) => status = abilityStatus;

    public void ChangeCooldownTimer(float timer)
    {
        cooldownTimer = Mathf.Clamp(timer, 0f, cooldownTime);
        EventChangeCooldownTimer?.Invoke(cooldownTimer, cooldownTime);
    }
    public virtual void StartCast() { }
    public virtual bool CheckCondition(Player owner, Enemy target, Vector2 location = default) { return false; }
    public virtual void ApplyCast() { }
    public virtual void EventTick(float deltaTick) { }
    public virtual void CancelCast() { }
}
