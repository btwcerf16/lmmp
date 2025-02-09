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


        //_player.rigidbody2D.velocity = new Vector2(_player.transform.localScale.x * _player.dashPower, 0.0f);

        //_player.rigidbody2D.gravityScale = 0.0f;
        //_player.canRoll = false;
        //_player.State = "Roll";

        _player.assailable = false;
        _player.animator.SetBool("Roll", true);
        _player.canRoll = false;

        _player.rigidbody2D.velocity = new Vector2(0, 0);
        if (_player.faceRight)
        {
            _player.rigidbody2D.AddForce(Vector2.right * _player.dashPower);
        }
        else
        {
            _player.rigidbody2D.AddForce(Vector2.left * _player.dashPower);
        }
    }
    public override void Update()
    {
        base.Update();
        _player.rigidbody2D.velocity = new Vector2(0, 0);

    }
    public override void Exit()
    {
        base.Exit();
        _player.animator.SetBool("Roll", false);

        _player.assailable = true;
        _player.canRoll = true;

    }

}
