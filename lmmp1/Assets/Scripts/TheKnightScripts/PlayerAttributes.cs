using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerAttributes
{
    public Attributes atribute;
    public int amount;

    public PlayerAttributes(Attributes atribute, int amount)
    {
       
        this.amount = amount;
        this.atribute = atribute;
    }
}
