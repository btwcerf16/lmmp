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
        
    }

    
    public override void Update()
    {
        base.Update();
      
    }

    public override void Exit()
    {
        base.Exit();
        _player.animator.SetBool("Fall", false);
        
    }
}
