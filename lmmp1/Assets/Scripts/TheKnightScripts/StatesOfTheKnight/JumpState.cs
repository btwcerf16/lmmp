using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : State
{
    private Player _player;
    public JumpState(Player player)
    {
        _player = player;
    }

    
    public override void Enter()
    {
        base.Enter();
        _player.animator.SetBool("Jump", true);
        _player.rigidbody2D.AddForce(_player.jumpForce * Vector2.up, ForceMode2D.Impulse);
        _player.canMove = false;
    }


    public override void Update()
    {
        base.Update();
        _player.State = "Jump";
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) { _player.transform.position = new Vector2(_player.transform.position.x + 
            (_player.speed * Time.deltaTime * _player.moveVector.x) / 3, _player.transform.position.y); 
        }

        
        if (_player.moveVector.x > 0 && !_player.faceRight || _player.moveVector.x < 0 && _player.faceRight)
        {
            _player.Flip();
        }
    }

    public override void Exit()
    {
        base.Exit();
        _player.animator.SetBool("Jump", false);
        
    }
}
