using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    

    private Player _player;

    public float dashPower;

    public float coolDown = 0.7f;
    private float _timer;
    public float timer
    {
        get
        {
            return _timer;
        }
        set
        {
            _timer = Mathf.Max(0, value);
        }
    }

    private void Start()
    {
        _player = GetComponent<Player>();

        
        
    }

    
    private void Update()
    {
        _player.rigidbody2D.velocity = new Vector2(0, 0);
        if (timer > 0)
        {
            timer -= Time.deltaTime;

        }
    }
    public void DodgeDash()
    {
        if (_player.faceRight)
        {
            _player.rigidbody2D.AddForce(Vector2.right * dashPower);
        }
        else
        {
            _player.rigidbody2D.AddForce(Vector2.left * dashPower);
        }
        timer = coolDown;
    }
}
