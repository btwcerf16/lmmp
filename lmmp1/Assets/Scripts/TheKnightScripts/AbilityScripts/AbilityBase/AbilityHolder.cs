using System.Collections;
using System.Collections.Generic;
using UnityEditor.Playables;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    public List<Ability> abilities = new();
    public List<float> currentCooldownTime = new();
    public List<float> currentActiveTime = new();

    public List<KeyCode> keys = new();
    [SerializeField]private List<AbilityState> states = new();

    enum AbilityState
    {
        Ready,
        Active,
        Cooldown
    }
    



    private void Update()
    {
        for (int i = 0; i < abilities.Count; i++)
        {
            switch (states[i])
            {
                case AbilityState.Ready:
                    if (Input.GetKeyDown(keys[i]))
                    {

                        states[i] = AbilityState.Active;
                        currentActiveTime[i] = abilities[i].activeTime;
                    }
                    break;

                case AbilityState.Active:

                    if (currentActiveTime[i] > 0)
                    {
                        currentActiveTime[i] -= Time.deltaTime;
                        if (Input.GetKeyDown(KeyCode.Tab))
                        {
                            states[i] = AbilityState.Ready;
                        }
                    }
                    else
                    {
                        currentActiveTime[i] = 0;
                        abilities[i].Activate(gameObject);
                        abilities[i].BeginCooldown(gameObject);
                        states[i] = AbilityState.Cooldown;
                        currentCooldownTime[i] = abilities[i].cooldownTime;
                    }
                    break;

                case AbilityState.Cooldown:

                    if (currentCooldownTime[i] > 0)
                    {
                        currentCooldownTime[i] -= Time.deltaTime;
                    }
                    else
                    {
                        currentCooldownTime[i] = 0;
                        states[i] = AbilityState.Ready;
                    }
                    break;
            }
        }
        

    }
}
