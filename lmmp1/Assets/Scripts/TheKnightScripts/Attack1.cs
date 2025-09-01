using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Attack1 : MonoBehaviour, IAttacker
{
    
    [field: SerializeField ]public LayerMask enemyLayer { get; set; }
    [field:SerializeField] public Transform attack1point { get; set; }
    [field: SerializeField] public float attackArea { get; set; }
    [field: SerializeField] public float attackCooldown { get; set; }
    private Player player;
    


    private void Start()
    {
        player = GetComponent<Player>();
    }
    public void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attack1point.position, attackArea, enemyLayer);
        float roll = Random.value;

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.GetComponent<IDamageable>() != null)
            {
                
                if (roll <= player.currentStats.critChance/100.0f)
                {
                    enemy.GetComponent<IDamageable>().Damage(player.currentStats.attackDamage * player.currentStats.critDamage/100.0f * player.currentStats.physicDamageMultiplyer);
                    Debug.Log(" –»“ " + player.currentStats.attackDamage * player.currentStats.critDamage / 100.0f * player.currentStats.physicDamageMultiplyer + " ÿ¿Õ— " + roll);
                }
                else
                {
                    enemy.GetComponent<IDamageable>().Damage(player.currentStats.attackDamage * player.currentStats.physicDamageMultiplyer);
                    Debug.Log("ÕÂ –»“ " + player.currentStats.attackDamage * player.currentStats.physicDamageMultiplyer + " ÿ¿Õ— " + roll);
                }
            }
        }
       
    }
    private void OnDrawGizmosSelected()
    {
        if (attack1point == null)
        {
            return;
        }

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attack1point.position, attackArea);
    }

    public void Reloading()
    {
        throw new System.NotImplementedException();
    }
}
