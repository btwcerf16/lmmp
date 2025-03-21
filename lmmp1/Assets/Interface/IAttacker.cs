using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttacker
{
    LayerMask enemyLayer { get; set; }
    Transform attack1point { get; set; }
    float attackArea { get; set; }
    float coolDown { get; set; }
    float attackCooldown { get; set; }
    void Attack();
    void Reloading();
}
