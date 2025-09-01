using UnityEngine;
public class RunState : State
{
    private Player _player;
    
    
    public RunState(Player player)
    {
        _player = player;
    }

    public override void Enter()
    {
        base.Enter();
      
        _player.animator.SetBool("Run", true);
        _player.canAttack = false;
        _player.State = "Run";
    }
    public override void Update()
    {
        base.Update();
        

        _player.transform.position = new Vector2(_player.transform.position.x + (_player.currentStats.speed * Time.deltaTime * _player.moveVector.x), _player.transform.position.y);
        
        if (_player.moveVector.x > 0 && !_player.faceRight || _player.moveVector.x < 0 && _player.faceRight)
        {
           

            _player.Flip();
            _player.animator.SetTrigger("TurnAround");

        }

    }
    public override void Exit()
    {
        base.Exit();
        _player.animator.SetBool("Run", false);
        _player.canAttack = true;
    }
}
