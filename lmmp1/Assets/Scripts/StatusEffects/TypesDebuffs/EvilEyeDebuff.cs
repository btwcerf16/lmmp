using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Character/Create Debuff/EvilEye Debuff")]
public class EvilEyeDebuff : Buff
{
    public int HitToDeath;
    public int Hits;
    public float DamagePercent;
    private IEnumerator activeCoroutines;

    public override void Apply(ActorStats stats, MonoBehaviour owner)
    {
        if (activeCoroutines == null)
        {
            activeCoroutines = DurationOfDeBuff(stats, owner);

            owner.StartCoroutine(activeCoroutines);
            Hits = 1;
            
            owner.GetComponent<BuffUIHandler>().ShowBuff(this);

        }
        else
        {
            owner.StopCoroutine(activeCoroutines);
            owner.GetComponent<BuffUIHandler>().HideBuff(this);
            activeCoroutines = DurationOfDeBuff(stats, owner);
            Hits++;
            Debug.Log(Hits);

            owner.GetComponent<BuffUIHandler>().ShowBuff(this);
            owner.StartCoroutine(activeCoroutines);
            if (Hits == HitToDeath)
            {
                stats.currentHealth -= stats.maxHealth * DamagePercent / 100.0f;
                Hits = 0;
            }
        }
    }
    IEnumerator DurationOfDeBuff(ActorStats stats, MonoBehaviour owner)
    {
        yield return new WaitForSeconds(Duration);
        Hits = 0;
        owner.GetComponent<BuffUIHandler>().HideBuff(this);


    }
}
