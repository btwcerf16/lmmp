using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Player : MonoBehaviour, IDamageable
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
    public float baseGravityScale = 1.0f;  
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

    [Header("Currently State")]
    public string State = "";

    [Header("Health Settings")]
    public float visibleCurrentlyHealth;
    [field:SerializeField] public float maxHealth { get; set; } = 15.0f;
    [field:SerializeField] public float currentHealth { get; set; }


    

  
    


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
        visibleCurrentlyHealth = currentHealth;
        _SM.currentState.Update();
        moveVector.x = Input.GetAxis("Horizontal");
        CheckingGround();
        

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) && canMove)
        {
            
            _SM.ChangeState(new RunState(this));

        }
        //if (rigidbody2D.velocity.y == 0 && rigidbody2D.velocity.x == 0 && canAttack)
        if(moveVector.x == 0 && rigidbody2D.velocity.x == 0 && canAttack && canRoll)
        {
            _SM.ChangeState(new IdleState(this));
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && canAttack && attack1.waitTime == 0)
        {
            _SM.ChangeState(new Attack1State(this));
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
    private void CheckingGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundMask);
    }

    public void Die()
    {
        Destroy(gameObject);
    }
    
}
