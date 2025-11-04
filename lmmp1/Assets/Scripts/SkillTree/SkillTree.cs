using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkillTree : MonoBehaviour
{
    public SkillSlot[] SkillSlots;
    public TMP_Text AbilityPointsText;
    public int AvailableAbilityPoints;

    private void Start()
    {
        foreach (var slot in SkillSlots)
        {
            slot.SlotButton.onClick.AddListener(()=> CheckAvailablePoints(slot));

        }
        UpdateAbilityPoints(1);
    }
    private void CheckAvailablePoints(SkillSlot _slot)
    {
        if(AvailableAbilityPoints > 0)
        {
            _slot.TryUpgradeSkill();
        }
    }
    public void UpdateAbilityPoints(int amount)
    {
        AvailableAbilityPoints += amount;
        AbilityPointsText.text = $"Points: {AvailableAbilityPoints}";
    }
    private void HandleAbilityPointsSpent(SkillSlot _skillSlot)
    {
        if(AvailableAbilityPoints > 0)
        {
            UpdateAbilityPoints(-1);
        }
    }
    private void HandleAbilityMaxed(SkillSlot _skillSlot)
    {
        Debug.Log("ְּÊׁ");
        foreach(SkillSlot slot in SkillSlots)
        {
            if(!slot.IsUnlocked && slot.CanUnlockAbility())
            {
                slot.Unlock();
            }
            
        }
    }
    private void OnEnable()
    {
        SkillSlot.OnAbilityPointSpent += HandleAbilityPointsSpent;
        SkillSlot.OnAbilityMaxed += HandleAbilityMaxed;
    }



    private void OnDisable()
    {
        SkillSlot.OnAbilityPointSpent -= HandleAbilityPointsSpent;
        SkillSlot.OnAbilityMaxed -= HandleAbilityMaxed;
    }

}
