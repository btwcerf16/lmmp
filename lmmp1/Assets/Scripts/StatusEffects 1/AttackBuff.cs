using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Character/Create Buff/Damage Buff")]
public class AttackBuff : ScriptableObject, IBuff
{
    public float DamageBuff;
    public float Duration;

    public void Apply(ActorStats stats, MonoBehaviour owner)
    {
        owner.StartCoroutine(DurationOfBuff(stats));
        stats.attackDamage += DamageBuff;
        Debug.Log(stats.attackDamage);
    }
    IEnumerator DurationOfBuff(ActorStats stats)
    {
        yield return new WaitForSeconds(Duration);
        stats.attackDamage -= DamageBuff;
        Debug.Log(stats.attackDamage);
    }
}
