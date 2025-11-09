using System.Collections;
using System.Collections.Generic;
using UnityEditor.Playables;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    public List<Ability> Abilities = new();
    public KeyCode CancelKey = KeyCode.Tab;
    private void Update()
    {
        for (int i = 0; i < Abilities.Count; i++)
        {

            switch (Abilities[i].State)
            {
                case EAbilityStates.Ready:
                    if (Input.GetKeyDown(Abilities[i].AbilityData.KeyActivation))
                    {

                        Abilities[i].State = EAbilityStates.Active;
                        Abilities[i].ActiveTimeRemaining = Abilities[i].AbilityData.AbilityActiveTime;
                    }
                    break;

                case EAbilityStates.Active:

                    if (Abilities[i].ActiveTimeRemaining > 0)
                    {
                        Abilities[i].ActiveTimeRemaining -= Time.deltaTime;//перенеси в метод евент тик потом 
                        if (Input.GetKeyDown(KeyCode.Tab))
                        {
                            Abilities[i].State = EAbilityStates.Ready;
                        }
                    }
                    else
                    {
                        Abilities[i].ActiveTimeRemaining = 0;
                        Abilities[i].ApplyCast();

                        Abilities[i].State = EAbilityStates.Cooldown;
                        Abilities[i].CooldownTimeRemaining = Abilities[i].AbilityData.AbilityCooldown;
                    }
                    break;

                case EAbilityStates.Cooldown:

                    if (Abilities[i].CooldownTimeRemaining > 0)
                    {
                        Abilities[i].BeginCooldown();
                        Abilities[i].CooldownTimeRemaining -= Time.deltaTime;
                    }
                    else
                    {
                        Abilities[i].CooldownTimeRemaining = 0;
                        Abilities[i].State = EAbilityStates.Ready;
                    }
                    break;
            }
            if (Abilities[i].AbilityData.HasPassive)
            {
                Abilities[i].Added();
            }
        }


    }
    
    public void AddAbility(Ability ability)
    {
        
        Ability existing = Abilities.Find(_ability => ability == _ability);
        if (existing != null)
        {
            return;
        }
        else 
        {
            Abilities.Add(ability);
        }
        
    }
    public void RemoveAbility(Ability ability) 
    {
        Ability existing = Abilities.Find(_ability => ability == _ability);
        if (existing != null)
        {
            Abilities.Remove(ability);
        }
    }

}

