using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DomainDataHandler : MonoBehaviour
{
    public Enemy EnemyDomainChildren;


    private void Awake()
    {
        EnemyDomainChildren = GetComponentInChildren<Enemy>();
    }
}
