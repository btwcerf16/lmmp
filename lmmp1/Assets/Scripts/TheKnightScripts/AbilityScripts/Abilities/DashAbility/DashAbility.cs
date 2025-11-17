using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;


public class DashAbility : Ability
{
    private TrailRenderer trailRenderer;
    private Player player;
    

    private void Start()
    {
        trailRenderer = GetComponent<TrailRenderer>();
        player = GetComponent<Player>();
    }
    public override void Added()
    {
        base.Added();
    }

    public override void ApplyCast()
    {
        StartCoroutine(Dash());
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
    IEnumerator Dash()
    {
        player.ChangePlayerState(new RollState(player));
        player.rigidbody2D.gravityScale = 0.0f;
        player.rigidbody2D.velocity = new Vector2(transform.localScale.x * ((DashAbilityData)AbilityData).DashPower[CurrentAbilityLevel-1] * player.currentStats.speed / 10.0f, 0f);
        trailRenderer.emitting = true;
        yield return new WaitForSeconds(((DashAbilityData)AbilityData).DashTime[CurrentAbilityLevel-1]);
        trailRenderer.emitting = false;
        player.rigidbody2D.gravityScale = player.baseGravityScale;
        //_isDashing = false;
        player.currentStats.canMove = true;
        player.rigidbody2D.velocity = new Vector2(0f, 0f);
        yield return new WaitForSeconds(((DashAbilityData)AbilityData).AbilityCooldown[CurrentAbilityLevel]);
        player.canRoll = true;
    }
}
