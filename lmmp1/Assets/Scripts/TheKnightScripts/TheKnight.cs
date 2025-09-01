using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TheKnight : Player
{
    public AbilityHolder firstAbility;
    public AbilityHolder secondAbility;
    
    private void Start()
    {
        firstAbility = GetComponent<AbilityHolder>();
        secondAbility = GetComponent<AbilityHolder>();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            
        }
    }
}
