using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Dash : MonoBehaviour
{
    

    private Player _player;
    //private bool _isDashing;
    public float dashTime;
    public float dashPower;

    [SerializeField] private TrailRenderer trailRenderer;

    public float coolDown;
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
        
        if (timer > 0)
        {
            timer -= Time.deltaTime;

        }
    }
    public void DodgeDash()
    {
        timer = coolDown;
        StartCoroutine(CanRoll());
    }
    IEnumerator CanRoll() {
        
        //_isDashing = true;
        _player.rigidbody2D.gravityScale = 0.0f;
        _player.rigidbody2D.velocity = new Vector2(transform.localScale.x * dashPower * _player.currentStats.speed, 0f);
        trailRenderer.emitting = true;
        yield return new WaitForSeconds(dashTime);
        trailRenderer.emitting = false;
        _player.rigidbody2D.gravityScale = _player.baseGravityScale;
        //_isDashing = false;
        _player.currentStats.canMove = true;
        _player.rigidbody2D.velocity = new Vector2(0f, 0f);
        yield return new WaitForSeconds(coolDown);
        _player.canRoll = true;
        
    }

}
