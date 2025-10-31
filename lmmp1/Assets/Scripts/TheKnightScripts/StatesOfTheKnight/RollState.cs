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


        
        _player.currentStats.canMove = false;
        _player.currentStats.assailable = false;
        _player.State = "Dash";
        
        _player.animator.SetBool("Roll", true);
        
        
    }
    public override void Update()
    {
        base.Update();

        

    }
    public override void Exit()
    {
        base.Exit();
        
        _player.animator.SetBool("Roll", false);
        _player.currentStats.assailable = true;


    }

}
