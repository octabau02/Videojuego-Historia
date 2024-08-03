using UnityEngine;
using System.Collections;

public class Bandit : MonoBehaviour {

    [SerializeField] float      m_speed = 4.0f;
    [SerializeField] float      m_jumpForce = 7.5f;
    [SerializeField] float      life = 100f;  
    [SerializeField] float      attackRange = 1.0f;  
    private float attackCooldown = 1.5f; // Tiempo en segundos entre ataques
    private float lastAttackTime;

    private Animator            m_animator;
    private Rigidbody2D         m_body2d;
    private Sensor_Bandit       m_groundSensor;
    private bool                m_grounded = false;
    private bool                m_combatIdle = false;
    private bool                m_isDead = false;

    public Transform player;
    public float detectionRadious = 5.0f;
    private Rigidbody2D rb;
    private Vector2 movement;

    public int health;

    public int daño_b;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
        m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor_Bandit>();
    }
	
	// Update is called once per frame
	void Update () {
        //Check if character just landed on the ground
        if (!m_grounded && m_groundSensor.State()) {
            m_grounded = true;
            m_animator.SetBool("Grounded", m_grounded);
        }

        //Check if character just started falling
        if(m_grounded && !m_groundSensor.State()) {
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
        }

        if (health <= 0) {
            m_animator.SetTrigger("Death");
            m_isDead = true;
            Destroy(gameObject);
        }
        // -- Handle input and movement --
        /*
        float inputX = Input.GetAxis("Horizontal");

        // Swap direction of sprite depending on walk direction
        if (inputX > 0)
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (inputX < 0)
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        // Move
        m_body2d.velocity = new Vector2(inputX * m_speed, m_body2d.velocity.y);
        
        //Set AirSpeed in animator
        m_animator.SetFloat("AirSpeed", m_body2d.velocity.y);

        // -- Handle Animations --
        //Death
        if (Input.GetKeyDown("e")) {
            if(!m_isDead)
                m_animator.SetTrigger("Death");
            else
                m_animator.SetTrigger("Recover");

            m_isDead = !m_isDead;
        }
            
        //Hurt
        else if (Input.GetKeyDown("q"))
            m_animator.SetTrigger("Hurt");

        //Attack
        else if(Input.GetMouseButtonDown(0)) {
            m_animator.SetTrigger("Attack");
        }

        //Change between idle and combat idle
        else if (Input.GetKeyDown("f"))
            m_combatIdle = !m_combatIdle;

        //Jump
        else if (Input.GetKeyDown("space") && m_grounded) {
            m_animator.SetTrigger("Jump");
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
            m_body2d.velocity = new Vector2(m_body2d.velocity.x, m_jumpForce);
            m_groundSensor.Disable(0.2f);
        }

        //Run
        else if (Mathf.Abs(inputX) > Mathf.Epsilon)
            m_animator.SetInteger("AnimState", 2);

        //Combat Idle
        else if (m_combatIdle)
            m_animator.SetInteger("AnimState", 1);

        //Idle
        else
            m_animator.SetInteger("AnimState", 0);*/

        m_animator.SetInteger("AnimState", 0);

        float distantToPlayer = Vector2.Distance(transform.position, player.position);
        if(distantToPlayer < detectionRadious){
            Vector2 direction = (player.position - transform.position).normalized;
            movement = new Vector2(direction.x, 0);

        if (distantToPlayer <= attackRange) {
        // Iniciar el ataque y detener el movimiento
        if (Time.time >= lastAttackTime + attackCooldown) {
            AttackPlayer();
            lastAttackTime = Time.time;
        }

        // Detener el movimiento durante el ataque
        movement = Vector2.zero;


        } else {
            // Mover hacia el jugador
            m_animator.SetInteger("AnimState", 2);
            rb.MovePosition(rb.position + movement * m_speed * Time.deltaTime);
        }

            // Swap direction of sprite depending on walk direction
        if (movement.x > 0)
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (movement.x < 0)
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }else{
            movement = Vector2.zero;
            m_animator.SetInteger("AnimState", 0);

        }

    }

    public void TakeDamage(int damage){
        health -= damage;
        m_animator.SetTrigger("Hurt");
    }

    public void AttackPlayer(){
        m_animator.SetTrigger("Attack");
        player.GetComponent<HeroKnight>().TakeDamage(daño_b);
    }
}
