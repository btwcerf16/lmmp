using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringerOfDeathSpell : MonoBehaviour
{
  

    public List<Transform> SpellPoints;

    public GameObject SpellPrefab;


  
    private void CastSpell()
    {
        Instantiate(SpellPrefab, SpellPoints[Random.Range(0, 3)]);
    }
}
