public class IdleState : State
{
    private Player _player;

    public IdleState(Player player)
    {
        _player = player;
    }
    public override void Enter()
    {
        base.Enter();
        _player.animator.SetBool("Idle", true);

    }
    public override void Update()
    {
        base.Update();
        
    }
    public override void Exit()
    {
        base.Exit();
        _player.animator.SetBool("Idle", false);

    }
}
