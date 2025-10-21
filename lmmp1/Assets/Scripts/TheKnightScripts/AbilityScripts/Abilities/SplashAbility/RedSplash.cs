using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class RedSplash : MonoBehaviour
{
    private Player player;
    private Vector2 attackPoint;
    public float AttackArea;
    public LayerMask EnemyLayer;
    public float DamagePercent;


    public EffectData effect;
    private void Awake()
    {
        player = GetComponentInParent<Player>();
        attackPoint = new Vector2(transform.position.x, transform.position.y);
    }

    private void SplashDamage()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint, AttackArea, EnemyLayer);
        

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.GetComponent<IDamageable>() != null)
            {
                CameraShake.Instance.ShakeCamera(2.5f, 0.1f);
                if (player.currentStats.ÑurrentStamina >= 0)
                { enemy.GetComponent<IDamageable>().Damage(((
                    (player.currentStats.GetTotalDamage()) * DamagePercent/100.0f) * 0.6f)); }

                else { enemy.GetComponent<IDamageable>().Damage(((player.currentStats.GetTotalDamage()) * DamagePercent / 100.0f));
                    enemy.GetComponent<EffectHandler>().AddEffect(effect);
                }
                
            }
        }
        
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint, AttackArea);
    }
    private void DestroyOnEnd()
    {
        Destroy(gameObject);
    }
}
