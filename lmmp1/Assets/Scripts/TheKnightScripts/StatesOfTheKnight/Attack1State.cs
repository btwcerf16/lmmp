using UnityEngine;

public class Attack1State : State
{
    private Player _player;

    public Attack1State(Player player)
    {
        _player = player;
    }

    public override void Enter()
    {
        base.Enter();
        _player.animator.SetTrigger("Attack1");
        _player.groundCheckRadius = 0;
        _player.State = "Attack";

    }
    public override void Update()
    {
        base.Update();
        
    }
    public override void Exit()
    {
        base.Exit();
        _player.groundCheckRadius = 0.3f;
        
    }
}
