using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Reference: https://www.youtube.com/watch?v=u8tot-X_RBI&t=1s&ab_channel=BMo
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    [SerializeField] private float stamina = 200f;

    //health components
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        //process inputs, update based on FPS
        ProcessInputs();
<<<<<<< Updated upstream
        ProcessSprint();
=======
 
    }

    void OnCollisionEnter2D(Collision2D hitInfo)
    {
        if (hitInfo.gameObject.tag == "Enemy")
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
>>>>>>> Stashed changes
    }

    void FixedUpdate()
    {
        //process physics, independent of FPS
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    void ProcessSprint()
    {
        if(Input.GetButton("Fire3") && stamina > 0f)
        {
            moveSpeed = 8;
            stamina -= 0.5f;
        }
        else
        {
            moveSpeed = 5;
        }
        if(stamina < 200 && !(Input.GetButton("Fire3")))
        {
            stamina += 0.40f;
        }
    }

}
