using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringerOfDeathSpell : MonoBehaviour
{
  

    public List<Transform> SpellPoints;

    public GameObject SpellPrefab;

    [SerializeField]private Transform DomainParent;

    private void CastSpell()
    {
        Instantiate(SpellPrefab, SpellPoints[Random.Range(0, SpellPoints.Count)].position,Quaternion.Euler(0f,0f,0f), DomainParent);
    }
}
