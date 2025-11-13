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
    public bool IsActive;
    private void Start()
    {
        abilityStorage = GetComponentInParent<AbilityStorage>();
    }
    private void Update()
    {
        IsActive = abilityStorage.AbilityDatas[ability];
    }
    public void ChangeItemData(Ability _ability)
    {
        ability = _ability;
        AbilityItemImage.sprite = _ability.AbilityData.AbilityIcon;
    }
    public void ChangeAbilityState()
    {
        switch (IsActive)
        {
            case true:
                abilityStorage.ReturnAbilityToStorage(ability);
                ButtonText.text = "Âêëş÷èòü";
                Debug.Log("ÂÛÏÎËÍÅÍÎ");
                break;
            case false:
                abilityStorage.TransferAbilityToHolder(ability);
                ButtonText.text = "Âûêëş÷èòü";
                Debug.Log("!ÂÛÏÎËÍÅÍÎ");
                break;
        }
    }
    


}
