using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttacker
{
    
    [field: SerializeField] public LayerMask enemyLayer { get; set; }
    [field: SerializeField] public Transform attack1point { get; set; }
    [field: SerializeField] public float attackArea { get; set; }

    [field: SerializeField] public float attackCooldown { get; set; }
    void Attack();
    void Reloading();
}
