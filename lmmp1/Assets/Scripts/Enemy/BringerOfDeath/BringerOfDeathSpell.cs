using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringerOfDeathSpell : MonoBehaviour
{
  

    [SerializeField]private Transform SpellPoint;

    [SerializeField]private GameObject SpellPrefab;

    [SerializeField]private Transform DomainParent;

    [SerializeField] private float SpellRadius;
    private void CastSpell()
    {
        Vector2 randomPointInCircle = Random.insideUnitCircle * SpellRadius;
        Vector3 instantiatePos = new Vector3(randomPointInCircle.x * SpellRadius + SpellPoint.position.x, randomPointInCircle.y * SpellRadius + SpellPoint.position.y, 0.0f);
        Instantiate(SpellPrefab,instantiatePos ,Quaternion.Euler(0f,0f,0f), DomainParent);
    }
}
