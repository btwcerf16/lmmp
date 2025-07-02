using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttacker
{
    
    [SerializeField] public LayerMask enemyLayer { get; set; }
    [SerializeField] public Transform attack1point { get; set; }
    [SerializeField] public float attackArea { get; set; }

    [SerializeField] public float attackCooldown { get; set; }
    void Attack();
    void Reloading();
}
