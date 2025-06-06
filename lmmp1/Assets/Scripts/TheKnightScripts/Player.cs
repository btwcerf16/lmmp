using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Player : MonoBehaviour, IDamageable, ITeamable
{
    
    

    [HideInInspector] public Animator animator;
    [HideInInspector] public new Rigidbody2D rigidbody2D;
    [Header("Type of Attack")]

    public Attack1 attack1;
    [Header("Dash Specimen")]
    public Dash dash;
    [Header("Move variable")]
    public bool faceRight = true;
    public Vector2 moveVector;
    private StateMachine _SM;
    public float speed = 10.0f;

    [Header("Jump Settings")]
    public float baseGravityScale;  
    public float jumpForce = 10.0f;
    public float jumpHeight = 10.0f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.3f;
    public bool isGrounded;
    public LayerMask groundMask;

    [Header("Statuses of Player")]
    public bool assailable = true;
    public bool canAttack = true;
    public bool canJump = true;
    public bool canRoll;
    public bool canMove = true;
    public bool isPlayer { get; set; }

    [Header("Currently State")]
    public string State = "";

   
    
    [field:SerializeField] public float maxHealth { get; set; } = 15.0f;
    [field:SerializeField] public float currentHealth { get; set; }
    

    [Header("Player Attributes")]
   
    public List<PlayerAttributes> Attribute = new List<PlayerAttributes>();
    
    



    private void Start()
    {
        
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        attack1 = GetComponent<Attack1>();

        _SM = new StateMachine();
        _SM.Initialize(new IdleState(this));

        currentHealth = maxHealth;

        baseGravityScale = rigidbody2D.gravityScale;
    }
    private void Update()
    {
        
        _SM.currentState.Update();
        moveVector.x = Input.GetAxis("Horizontal");
        CheckingGround();

        if (Input.GetKey(KeyCode.V))
        {

            Heal(1);

        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) && canMove)
        {

            _SM.ChangeState(new RunState(this));

        }
        //if (rigidbody2D.velocity.y == 0 && rigidbody2D.velocity.x == 0 && canAttack)
        if (moveVector.x == 0 && rigidbody2D.velocity.x == 0 && canAttack && canRoll && attack1.waitTime == 0)
        {
            _SM.ChangeState(new IdleState(this));
        }
        if (attack1.waitTime == 0) { 
            if (Input.GetKeyDown(KeyCode.Mouse0) && canAttack)
            {
                _SM.ChangeState(new Attack1State(this));
            }
        
        }
        if (Input.GetKeyDown(KeyCode.Space) && canJump && isGrounded)
        {
            _SM.ChangeState(new JumpState(this));
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && canRoll && dash.timer == 0)
        {
            _SM.ChangeState(new RollState(this));
        }
        
        if (rigidbody2D.velocity.y < 0)
        {
            _SM.ChangeState(new FallState(this));
        }

        if(Input.GetKeyDown(KeyCode.I))
        {
            canRoll = true;    
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
    public void Heal(float healAmount)
    {
        currentHealth += healAmount;
    }
    private void CheckingGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundMask);
    }

    public void Die()
    {
        Destroy(gameObject);
    }
    
}
