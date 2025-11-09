using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilityItemDisplay : MonoBehaviour
{
    public Image AbilityItemImage;
    [SerializeField]private Ability ability;
    private AbilityStorage abilityStorage;
    public TMP_Text ButtonText;
    private void Start()
    {
        abilityStorage = GetComponentInParent<AbilityStorage>();
    }
    public void ChangeItemData(Ability _ability)
    {
        ability = _ability;
        AbilityItemImage.sprite = _ability.AbilityData.AbilityIcon;
    }
    public void ChangeAbilityState()
    {
        bool isActive = abilityStorage.AbilityDatas[ability];
        if (isActive)
        {
            abilityStorage.ReturnAbilityToStorage(ability);
            ButtonText.text = "Включить";
        }
        else
        {
            abilityStorage.TransferAbilityToHolder(ability);
            ButtonText.text = "Выключить";
        }
    }



}
