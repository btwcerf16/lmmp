using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Windows;

public class AbilityStorage : MonoBehaviour
{
    public Dictionary<Ability, bool> AbilityDatas = new Dictionary<Ability, bool>(); //false - not active; true - is active
    [SerializeField] private AbilityHolder abilityHolder;
    [SerializeField] private AbilityStorageDisplay display;
    private void Start()
    {
        abilityHolder = GetComponent<AbilityHolder>();
        display = GetComponentInChildren<AbilityStorageDisplay>();
    }
    public void AddAbility(Ability _ability)
    {

        AbilityDatas.Add(_ability, false);
        display.AddAbilityItem(_ability);
    }
    public void TransferAbilityToHolder(Ability _ability)
    {
        abilityHolder.AddAbility(_ability);
        AbilityDatas[_ability] = true;
    }
    public void ReturnAbilityToStorage(Ability _ability)
    {
        AbilityDatas[_ability] = false;
        abilityHolder.RemoveAbility(_ability);
       
    }
    public void GiveOutAbility(AbilityData _abilityData)
    {

        if (IsExist(_abilityData))
        {
            return;
        }
        else
        {
            Ability newAbility = _abilityData.CreateAbility(gameObject);
            AddAbility(newAbility);
        }

    }
    public bool IsExist(AbilityData _ability)
    {
        foreach (var ability in AbilityDatas)
        {
            if (ability.Key.AbilityData == _ability)
            {
                return true;
            }
            
        }
        return false;
    }
}

//дело в том что сейчас он не проверяет есть ли на игроке способность а только в холдере попробуй через сторедж