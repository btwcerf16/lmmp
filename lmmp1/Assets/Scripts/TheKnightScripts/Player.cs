using UnityEngine;
using UnityEngine.Rendering;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Player : MonoBehaviour, IDamageable
{
    [HideInInspector] public Animator animator;
    [HideInInspector] public new Rigidbody2D rigidbody2D;
    public bool faceRight = true;
    public Vector2 moveVector;
    private StateMachine _SM;

    private float _maxHealth = 15.0f;
    public float currentHealth;
    public float jumpForce = 10.0f;
    public float speed = 10.0f;

    public bool assailable = true;
    public bool canAttack = true;
    public bool canJump = true;
    public bool canRoll = true;
    

    public Transform groundCheck;
    public float groundCheckRadius = 0.3f; 
    

    public LayerMask groundMask;

    

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();

        _SM = new StateMachine();
        _SM.Initialize(new IdleState(this));

        currentHealth = _maxHealth;
    }
    private void Update()
    {
        _SM.currentState.Update();
        moveVector.x = Input.GetAxis("Horizontal");
        CheckingGround();
        

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            _SM.ChangeState(new RunState(this));
        }
        else
        {
            _SM.ChangeState(new IdleState(this));
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && canAttack)
        {
            _SM.ChangeState(new Attack1State(this));
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && canRoll)
        {
            _SM.ChangeState(new RollState(this));
        }
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            _SM.ChangeState(new JumpState(this));
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
            Destroy(gameObject);
        }
    }
    private void CheckingGround()
    {
        canJump = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundMask);
    }

}
