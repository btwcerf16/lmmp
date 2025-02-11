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


        
        _player.canMove = false;
        _player.assailable = false;
        _player.State = "Dash";
        
        _player.animator.SetBool("Roll", true);
        _player.dash.DodgeDash();
        
    }
    public override void Update()
    {
        base.Update();

        

    }
    public override void Exit()
    {
        base.Exit();
        
        _player.animator.SetBool("Roll", false);
        _player.assailable = true;


    }

}
