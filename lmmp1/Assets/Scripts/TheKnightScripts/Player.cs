using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Player : MonoBehaviour, IDamageable
{
    [HideInInspector] public Animator animator;
    [HideInInspector] public new Rigidbody2D rigidbody2D;
     public Attack1 attack1;

    public bool faceRight = true;
    public Vector2 moveVector;
    private StateMachine _SM;

    public float baseGravityScale = 1.0f; 
    
    public float jumpForce = 10.0f;
    public float speed = 10.0f;
    public float dashPower = 16.0f;

    public bool assailable = true;
    public bool canAttack = true;
    public bool canJump = true;
    public bool canRoll = true;
    public bool canMove = true;

    public string State = "";

    public Transform groundCheck;
    public float groundCheckRadius = 0.3f; 
    

    public LayerMask groundMask;

    public float maxHealth { get; set; } = 15.0f;
    public float currentHealth { get; set; }

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        attack1 = GetComponent<Attack1>();

        _SM = new StateMachine();
        _SM.Initialize(new IdleState(this));

        currentHealth = maxHealth;

        rigidbody2D.gravityScale = baseGravityScale;
    }
    private void Update()
    {
        _SM.currentState.Update();
        moveVector.x = Input.GetAxis("Horizontal");
        CheckingGround();
        

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) && canMove)
        {
            
            _SM.ChangeState(new RunState(this));

        }
        //if (rigidbody2D.velocity.y == 0 && rigidbody2D.velocity.x == 0 && canAttack)
        if(moveVector.x == 0 && rigidbody2D.velocity.x == 0 && canAttack)
        {
            _SM.ChangeState(new IdleState(this));
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && canAttack && attack1.timer == 0)
        {
            _SM.ChangeState(new Attack1State(this));
        }
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            _SM.ChangeState(new JumpState(this));
        }
        if (Input.GetKey(KeyCode.LeftShift) && canRoll)
        {
            _SM.ChangeState(new RollState(this));
        }
        
        if (rigidbody2D.velocity.y < 0)
        {
            _SM.ChangeState(new FallState(this));
        }

        

    }


    public void Flip()
    {
        transform.localScale *= new Vector2(-1, 1);
        faceRight = !faceRight;
    }

    public void Damage(float damageAmount)
    {
        if (assailable)
        {
            currentHealth -= damageAmount;
        }


        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void CheckingGround()
    {
        canJump = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundMask);
    }

    public void Die()
    {
        Destroy(gameObject);
    }
    
}
