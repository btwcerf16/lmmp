using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyEnemy : MonoBehaviour, IDamageable
{
    private float _maxHealth = 10.0f;
    public float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = _maxHealth;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Damage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Debug.Log("Pomer");
        }
    }
}
