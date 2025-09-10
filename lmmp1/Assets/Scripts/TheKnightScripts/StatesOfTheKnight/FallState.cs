using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : State
{
    private Player _player;
    public FallState(Player player)
    {
        _player = player;
    }
    public override void Enter()
    {
        base.Enter();
        _player.animator.SetBool("Fall", true);
        _player.currentStats.canAttack = false;
        _player.State = "Fall";
    }

    
    public override void Update()
    {
        base.Update();
        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            _player.transform.position = new Vector2(_player.transform.position.x +
            (_player.currentStats.speed * Time.deltaTime * _player.moveVector.x) / 3, _player.transform.position.y);
        }


        if (_player.moveVector.x > 0 && !_player.faceRight || _player.moveVector.x < 0 && _player.faceRight)
        {
            _player.Flip();
        }
    }

    public override void Exit()
    {
        base.Exit();
        _player.animator.SetBool("Fall", false);
        _player.currentStats.canAttack = true;
        _player.currentStats.canMove = true;
    }
}
