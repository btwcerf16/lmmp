public interface IDamageable
{
    void Damage(float damageAmount);
    void Heal(float healAmount);
    void Die();
    float maxHealth { get; set; }
    float currentHealth { get; set; }
}
