using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringerOfDeathSpell : MonoBehaviour
{
  

    public Transform SpellPoints;

    public GameObject SpellPrefab;



    private void CastSpell()
    {
        Instantiate(SpellPrefab, SpellPoints/*[Random.Range(0, SpellPoints.Count+1)].position*//*,Quaternion.Euler(0f,0f,0f),gameObject.transform*/);
    }
}
