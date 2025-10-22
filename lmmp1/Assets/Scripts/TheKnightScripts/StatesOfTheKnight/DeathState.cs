using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : State
{
    private Player _player;

    public DeathState(Player player)
    {
        _player = player;
    }
    public override void Enter()
    {
        base.Enter();
        _player.animator.SetTrigger("Death");
        _player.State = "Death";
        _player.enabled = false;
    }
    public override void Update()
    {
        base.Update();

    }
    public override void Exit()
    {
        base.Exit();

    }
}
