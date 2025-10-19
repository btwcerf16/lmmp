using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Attack1 : MonoBehaviour, IAttacker
{
    
    [field: SerializeField ]public LayerMask enemyLayer { get; set; }
    [field:SerializeField] public Transform attack1point { get; set; }
    [field: SerializeField] public float attackArea { get; set; }
    [field: SerializeField] public float AttackCooldown { get; set; }
    [field: SerializeField] public ActorStats actorStats { get; set; }

    
    public EffectData AttackEffect;


    private void Start()
    {
        actorStats = GetComponent<ActorStats>();
    }
    public void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attack1point.position, attackArea, enemyLayer);
        float roll = Random.value;
        PlayerEventBus.onPlayerAttack?.Invoke();
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.GetComponent<IDamageable>() != null)
            {
                
                if (roll <= actorStats.critChance/100.0f)
                {
                    enemy.GetComponent<IDamageable>().Damage(actorStats.GetTotalDamage() * actorStats.critDamage/100.0f);
                    enemy.GetComponent<EffectHandler>().AddEffect(AttackEffect);
                    CameraShake.Instance.ShakeCamera(5f, 0.1f);
                }
                else
                {
                    enemy.GetComponent<IDamageable>().Damage(actorStats.GetTotalDamage());
                    CameraShake.Instance.ShakeCamera(2.5f, 0.1f);
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

    
}
