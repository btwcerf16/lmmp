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
        _player.rigidbody2D.velocity = new Vector2(_player.transform.localScale.x * _player.dashPower, 0.0f);

        _player.rigidbody2D.gravityScale = 0.0f;
        _player.canRoll = false;
        _player.State = "Roll";
    }
    public override void Update()
    {
        base.Update();
        
        
    }
    public override void Exit()
    {
        base.Exit();
        _player.rigidbody2D.gravityScale = _player.baseGravityScale;
        _player.assailable = true;
        
    }

}
