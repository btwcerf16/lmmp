using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerAttributes
{
    public Attributes atribute;
    public float amount;

    public PlayerAttributes(Attributes atribute, float amount)
    {
       
        this.amount = amount;
        this.atribute = atribute;
    }
}
