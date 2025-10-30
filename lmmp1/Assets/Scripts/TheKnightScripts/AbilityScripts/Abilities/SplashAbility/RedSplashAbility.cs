using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class RedSplashAbility : Ability
{
    private ActorStats ownerStats;
    private Player ownerPlayer;
    private void Start()
    {
        ownerStats = GetComponent<ActorStats>();
        ownerPlayer = GetComponent<Player>();
    }
    public override void Added()
    {
        base.Added();
    }

    public override void ApplyCast()
    {
        if (ownerStats.�urrentStamina > 0.0f)
        {

           ownerPlayer.GetComponent<Stamina>().ChangeStaminaAmount(-20.0f);


        }
        else
        {
            ownerPlayer.GetComponent<IDamageable>().Damage(10.0f);
        }

        Vector2 SlashPosition = new Vector2(transform.position.x + 1.5f * transform.localScale.x, transform.position.y);
        transform.localScale = transform.localScale;
        if (transform.localScale.x == 1) 
        { Instantiate(((RedSplashAbilityData)AbilityData).RedSplashPrefab, SlashPosition, Quaternion.Euler(0, 0, 0), transform); }
        else 
        { Instantiate(((RedSplashAbilityData)AbilityData).RedSplashPrefab, SlashPosition, Quaternion.Euler(0, 180, 0), transform); }
        while(State == EAbilityStates.Active)
        {
            Debug.Log("�� ����� ����");
        }
    }

    public override void BeginCooldown()
    {
        base.BeginCooldown();
       
    }

    public override void CancelCast()
    {
        base.CancelCast();
    }

    public override void EventTick()
    {
        base.EventTick();
    }
    //public GameObject RedSplash;

    //private float speed;   
    //public override void Activate(GameObject owner)
    //{
    //    if (owner.GetComponent<ActorStats>().�urrentStamina > 0.0f)
    //    {

    //        owner.GetComponent<Stamina>().ChangeStaminaAmount(-20.0f);


    //    }
    //    else
    //    {
    //        owner.GetComponent<IDamageable>().Damage(10.0f);
    //    }
    //    speed = owner.GetComponent<ActorStats>().speed;
    //    owner.GetComponent<ActorStats>().speed = 0;

    //    Vector2 SlashPosition = new Vector2(owner.transform.position.x + 1.5f * owner.transform.localScale.x, owner.transform.position.y);
    //    RedSplash.transform.localScale = owner.transform.localScale;
    //    if(owner.transform.localScale.x == 1) { Instantiate(RedSplash, SlashPosition, Quaternion.Euler(0, 0, 0), owner.transform); }
    //    else { Instantiate(RedSplash, SlashPosition, Quaternion.Euler(0, 180, 0), owner.transform); }
    //}

    //public override void BeginCooldown(GameObject owner)
    //{
    //    owner.GetComponent<MonoBehaviour>().StartCoroutine(WhileActive(owner));
    //}

    //IEnumerator WhileActive(GameObject owner)
    //{


    //    yield return new WaitForSeconds(1.0f);
    //    owner.GetComponent<ActorStats>().speed = speed;
    //}
}
