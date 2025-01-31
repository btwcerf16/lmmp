using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollState : State
{
    private Player _player;
    public RollState(Player player)
    {
        _player = player;
    }
    public override void Enter()
    {
        base.Enter();
        _player.assailable = false;
        _player.animator.SetTrigger("Roll");
        _player.rigidbody2D.velocity = new Vector2((_player.moveVector.x * _player.speed) + 10, _player.rigidbody2D.velocity.y);
        _player.canRoll = false;
    }
    public override void Update()
    {
        base.Update();

    }
    public override void Exit()
    {
        base.Exit();

        _player.assailable = true;
        
    }

}
