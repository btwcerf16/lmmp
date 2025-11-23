using System;
using System.Collections;
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
        if (!_player.currentStats.IsStaned) 
        {
            _player.animator.SetBool("Jump", true);

            _player.rigidbody2D.AddForce(_player.currentStats.jumpForce * Vector2.up, ForceMode2D.Impulse);
            _player.currentStats.canMove = false;
            _player.currentStats.canAttack = false;
            _player.State = "Jump";
        }

       
    }


    public override void Update()
    {
        base.Update();
        

        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && !_player.currentStats.IsStaned)
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
        _player.animator.SetBool("Jump", false);

    }

    
}
