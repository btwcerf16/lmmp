using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    public Ability ability;
    public float currentCooldownTime;
    public float currentActiveTime;

    public KeyCode key;


    enum AbilityState
    {
        None,
        Ready,
        Active,
        Cooldown
    }
    AbilityState state = AbilityState.Ready;



    private void Update()
    {
        switch (state)
        {
            case AbilityState.Ready:
                if (Input.GetKeyDown(key))
                {

                    state = AbilityState.Active;
                    currentActiveTime = ability.activeTime;
                }
                break;

            case AbilityState.Active:

                if (currentActiveTime > 0)
                {
                    currentActiveTime -= Time.deltaTime;
                    if (Input.GetKeyDown(KeyCode.Tab))
                    {
                        state = AbilityState.Ready;
                    }
                }
                else
                {
                    currentActiveTime = 0;
                    ability.Activate(gameObject);
                    ability.BeginCooldown(gameObject);
                    state = AbilityState.Cooldown;
                    currentCooldownTime = ability.cooldownTime;
                }
                break;

            case AbilityState.Cooldown:

                if (currentCooldownTime > 0)
                {
                    currentCooldownTime -= Time.deltaTime;
                }
                else
                {
                    currentCooldownTime = 0;
                    state = AbilityState.Ready;
                }
                break;
        }

    }
}
