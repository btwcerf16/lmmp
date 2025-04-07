using UnityEngine;
public class DummyEnemy : MonoBehaviour, IDamageable
{


    public float maxHealth { get; set; } = 15.0f;
    public float currentHealth { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;   
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
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Pomer");
    }

    public void Heal(float healAmount)
    {
        throw new System.NotImplementedException();
    }
}
