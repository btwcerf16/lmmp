using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStats
{

    public float speed { get; set; }
    public float maxHealth { get; set; }
    public float maxStamina { get; set; }
    public float attackDamage { get; set; }
    public float jumpForce { get; set; }
    public float magicResistance { get; set; }
    public float physicResistance { get; set; }
    public float magicDamageMultiplyer { get; set; }
    public float physicDamageMultiplyer { get; set; }
    public float invincibleTimeFrame { get; set; }

}
