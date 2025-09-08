using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;

public abstract class Player : MonoBehaviour, IDamageable
{
    
   
    [HideInInspector] public Stamina stamina; 
    [HideInInspector] public Animator animator;
    [HideInInspector] public new Rigidbody2D rigidbody2D;



    [Header("Type of Attack")]
    //public Attack1 attack1;
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


    [Header("Player Attributes")]

    public List<PlayerAttributes> Attribute = new();

    public CharacterBaseStats baseStats { get;}
    
    

    public ActorStats currentStats;
    private HealthBar healthBar;

    public EffectHandler PlayerEffectHandler;
    public List<Effect> effects;

    public List<GameObject> HurtEffect;

    private void Start()
    {
        healthBar = GetComponent<HealthBar>();
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        //attack1 = GetComponent<Attack1>();
        stamina = GetComponent<Stamina>();

        PlayerEffectHandler = GetComponent<EffectHandler>();

        _SM = new StateMachine();
        _SM.Initialize(new IdleState(this));

        baseGravityScale = rigidbody2D.gravityScale;
    }
    private void Update()
    {
       
        
        _SM.currentState.Update();
        moveVector.x = Input.GetAxis("Horizontal");
        CheckingGround();


        if (Input.GetKeyDown(KeyCode.N))
        {
            PlayerEffectHandler.AddEffect(effects[1]);



        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            PlayerEffectHandler.AddEffect(effects[0]);



        }
        if ((canMove && currentStats.speed > 0 && Input.GetKey(KeyCode.A) )|| (Input.GetKey(KeyCode.D) && canMove && currentStats.speed > 0))
        {

            _SM.ChangeState(new RunState(this));

        }
       
        if (moveVector.x == 0 && rigidbody2D.velocity.x == 0 && canAttack && canRoll)
        {
            _SM.ChangeState(new IdleState(this));
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (canAttack)
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

        if (Input.GetKeyDown(KeyCode.I))
        {
            canRoll = true;
        }
        if (assailable && !isAttacked)
        {
            if (currentStats.currentStamina < currentStats.maxStamina) {
                stamina.RechargeStaminaAmount();
            }
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
            currentStats.currentHealth -= damageAmount;
         
            isAttacked = true;
            assailable = false;

            Vector2 damagePos = new Vector2(transform.position.x + Random.Range(-1.0f, 1.0f), transform.position.y + Random.Range(-1.0f, .5f));
            Instantiate(HurtEffect[Random.Range(0,2)], damagePos, Quaternion.identity);

            StartCoroutine(IFrame(currentStats.invincibleTimeFrame));
        }



    }
    public void Heal(float healAmount)
    {
        currentStats.currentHealth += healAmount;
        
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

   
   
}
