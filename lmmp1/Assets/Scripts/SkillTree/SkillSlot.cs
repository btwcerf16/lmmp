using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Unity.VisualScripting;
public class SkillSlot : MonoBehaviour
{
    public AbilityData AbilitySlotData;
    [SerializeField]private Ability ability;
    public AbilityHolder PlayerAbilityHolder;
    public List<SkillSlot> PrerequisiteAbilitySlots;
    public Image AbilitySlotIcon;
    public Button SlotButton;
    public bool IsUnlocked;
    public int CurrentLevel;
    public TMP_Text AbilityLevelText;

    public static event Action<SkillSlot> OnAbilityPointSpent;
    public static event Action<SkillSlot> OnAbilityMaxed;
    private void Awake()
    {
        PlayerAbilityHolder = GetComponentInParent<AbilityHolder>();
    }
    private void OnValidate()
    {
        if(AbilitySlotData != null && AbilityLevelText != null)
        {
            AbilitySlotIcon.sprite = AbilitySlotData.AbilityIcon;
            UpdateUI();
        }

    }
    private void UpdateUI()
    {
        if (IsUnlocked)
        {
            SlotButton.interactable = true;
            AbilityLevelText.text = CurrentLevel.ToString() + "/" + AbilitySlotData.MaxAbilityLevel.ToString();
            AbilitySlotIcon.color = Color.white;

        }
        else
        {
            SlotButton.interactable = false;
            AbilityLevelText.text = "Закрыт";
            AbilitySlotIcon.color = Color.grey;
        }
    }
    public void TryUpgradeSkill()
    {
        if(IsUnlocked && CurrentLevel < AbilitySlotData.MaxAbilityLevel)
        {
            if (CurrentLevel == 0)
            {
                PlayerAbilityHolder.AddAbility(AbilitySlotData);
                int abilityIndex = Mathf.Max(0, PlayerAbilityHolder.Abilities.Count - 1);
                ability = PlayerAbilityHolder.Abilities[abilityIndex];
            }
            CurrentLevel++;
            ability.CurrentAbilityLevel = CurrentLevel;
            OnAbilityPointSpent?.Invoke(this);
            UpdateUI();
            if(CurrentLevel == AbilitySlotData.MaxAbilityLevel)
            {
                OnAbilityMaxed?.Invoke(this);
            }
        }
            
    }
    public bool CanUnlockAbility()
    {
        foreach (SkillSlot slot in PrerequisiteAbilitySlots)
        {
            if (!slot.IsUnlocked || slot.CurrentLevel < slot.AbilitySlotData.MaxAbilityLevel) { return false; }
        }
        return true;
    }
    public void Unlock()
    {
        
        IsUnlocked = true;
        UpdateUI();
    }


}
