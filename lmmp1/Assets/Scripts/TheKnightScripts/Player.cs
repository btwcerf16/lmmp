using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Player : MonoBehaviour, IDamageable, IBuffable
{
    
   
    [HideInInspector] public Stamina stamina; 
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
    
    
    [Header("Jump Settings")]
    public float baseGravityScale;
    
    
    public Transform groundCheck;
    private float groundCheckRadius = 0.3f;
    public bool isGrounded;
    public LayerMask groundMask;

    [Header("Statuses of Player")]
    public bool assailable = true;
    public bool canAttack = true;
    public bool canJump = true;
    public bool canRoll;
    public bool canMove = true;

    public bool isAttacked;


 
    public string State = "";

    
    public float currentStamina;
    public float staminaRegeneration;
  
    

    
    [field: SerializeField] public float currentHealth { get; set; }


    [Header("Player Attributes")]

    public List<PlayerAttributes> Attribute = new List<PlayerAttributes>();

    public CharacterBaseStats BaseStats;
    



    public float speed;
    public float maxHealth;
    public float attackDamage;
    public float maxStamina;
    public float jumpForce;
    public float magicResistance;
    public float physicResistance;
    public float magicDamageMultiplyer;
    public float physicDamageMultiplyer;
    public float invincibleTimeFrame;


    private void Awake()
    {
        speed = BaseStats.BaseSpeed;
        maxHealth = BaseStats.BaseMaxHealth;
        attackDamage = BaseStats.BaseAttackDamage;
        maxStamina = BaseStats.BaseMaxStamina;
        jumpForce = BaseStats.BaseJumpForce;
        magicResistance = BaseStats.BaseMagicResistance;
        physicResistance = BaseStats.BasePhysicResistance;
        magicDamageMultiplyer = BaseStats.BaseMagicDamageMultiplyer;
        physicDamageMultiplyer = BaseStats.BasePhysicDamageMultiplyer;
        invincibleTimeFrame = BaseStats.BaseInvincibleTimeFrame;

    }

    private void Start()
    {
       
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        attack1 = GetComponent<Attack1>();
        stamina = GetComponent<Stamina>();

        currentStamina = maxStamina;
        currentHealth = maxHealth;

        _SM = new StateMachine();
        _SM.Initialize(new IdleState(this));



        baseGravityScale = rigidbody2D.gravityScale;
    }
    private void Update()
    {
       
        
        _SM.currentState.Update();
        moveVector.x = Input.GetAxis("Horizontal");
        CheckingGround();

        

        if (Input.GetKeyDown(KeyCode.V))
        {

            Debug.Log(currentHealth);
           


        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) && canMove)
        {

            _SM.ChangeState(new RunState(this));

        }
       
        if (moveVector.x == 0 && rigidbody2D.velocity.x == 0 && canAttack && canRoll && attack1.waitTime == 0)
        {
            _SM.ChangeState(new IdleState(this));
        }
        if ((Input.GetKey(KeyCode.Mouse0)))
        {
            if ((attack1.waitTime == 0))
            {
                if (canAttack)
                {
                    _SM.ChangeState(new Attack1State(this));

                }
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

        if (Input.GetKeyDown(KeyCode.I))
        {
            canRoll = true;
        }
        if (currentStamina < maxStamina && assailable && !isAttacked)
        {
            stamina.RechargeStaminaAmount();
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
            isAttacked = true;
            assailable = false;
            StartCoroutine(IFrame(invincibleTimeFrame));
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
    IEnumerator IFrame(float invincibleTimeFrame)
    {
        yield return new WaitForSeconds(invincibleTimeFrame);
        isAttacked = false;
        assailable = true;
    }

    public void AddBuff(IBuff buff)
    {
        
    }

    public void RemoveBuff(IBuff buff)
    {
       
    }
}
