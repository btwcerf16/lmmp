public interface IDamageable
{
    void Damage(float damageAmount);
    void Heal(float healAmount);
    void Die();
    
    float currentHealth { get; set; }
}
