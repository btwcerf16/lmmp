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
    [SerializeField] private List<AbilityDisplay> abilityDisplays;
    public int MaxCountActiveAbilities = 4;
    public int CurrentCountActiveAbilities;
    private void Awake()
    {
        abilityHolder = GetComponent<AbilityHolder>();
    }
    public void AddAbility(Ability _ability)
    {

        AbilityDatas.Add(_ability, false);
        display.AddAbilityItem(_ability);
    }
    public void TransferAbilityToHolder(Ability _ability)
    {
        if(CurrentCountActiveAbilities < MaxCountActiveAbilities) 
        {
            abilityHolder.AddAbility(_ability);
            AbilityDatas[_ability] = true;
            display.SetPreviewAbility(_ability.AbilityData.AbilityIcon);
            CurrentCountActiveAbilities++;
            for (int i = 0; i < abilityDisplays.Count; i++) {
                if (abilityDisplays[i].ContentAbility == null)
                {
                    abilityDisplays[i].SetData(_ability);
                    return;
                }
            }
        }

    }
    public void ReturnAbilityToStorage(Ability _ability)
    {
        AbilityDatas[_ability] = false;
        abilityHolder.RemoveAbility(_ability);
        display.UnSetPreviewAbility(_ability.AbilityData.AbilityIcon);
        CurrentCountActiveAbilities--;
        for (int i = 0; i < abilityDisplays.Count; i++)
        {
            if (abilityDisplays[i].ContentAbility == _ability) 
            {
                abilityDisplays[i].RemoveData();
                if (i != abilityDisplays.Count - 1)
                {
                    for (int j = i; j < abilityDisplays.Count - 1; j++)
                    {
                        abilityDisplays[j].SetData(abilityDisplays[j + 1].ContentAbility);
                    }

                    break;
                }
            }
        }

            
        
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