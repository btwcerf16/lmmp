using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Character/Create Buff/Damage Buff")]
public class AttackBuff : Buff
{
    public float DamageBuff;
    public float Duration;

    public override void Apply(ActorStats stats, MonoBehaviour owner)
    {
            
        stats.attackDamage += DamageBuff;
        owner.StartCoroutine(DurationOfBuff(stats, owner));
        owner.GetComponent<BuffUIHandler>()?.ShowBuff(Icon);
        Debug.Log(stats.attackDamage);   
    }

    IEnumerator DurationOfBuff(ActorStats stats, MonoBehaviour owner)
    {
        yield return new WaitForSeconds(Duration);
        owner.GetComponent<BuffUIHandler>()?.HideBuff(Icon);
        stats.attackDamage -= DamageBuff;
        Debug.Log(stats.attackDamage);
    }
}
