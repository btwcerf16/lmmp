using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Character/Create Buff/Crit Buff")]

public class CritChanceBuff : Buff
{
    public float CritDamageBuff;
    public float BuffChancePercent;
    public override void Apply(ActorStats stats, MonoBehaviour owner)
    {
        stats.critChance += BuffChancePercent;
        stats.critDamage += CritDamageBuff;
        owner.GetComponent<BuffUIHandler>()?.ShowBuff(this);
        owner.StartCoroutine(DurationOfBuff(stats, owner));
    }
    IEnumerator DurationOfBuff(ActorStats stats, MonoBehaviour owner)
    {
        yield return new WaitForSeconds(Duration);
        owner.GetComponent<BuffUIHandler>().HideBuff(this);
        stats.critChance -= BuffChancePercent;
        stats.critDamage -= CritDamageBuff;

    }
}
