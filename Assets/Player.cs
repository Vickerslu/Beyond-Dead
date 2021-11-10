using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Reference: https://www.youtube.com/watch?v=u8tot-X_RBI&t=1s&ab_channel=BMo
public class Player : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    [SerializeField] private float stamina = 200f;
    public float hp;
    public float maxHp;
    public HealthBar healthBar;
    private Part[] parts;

    void Start() {
        hp = maxHp;
        healthBar.SetMaxHealth(maxHp);
    }

    // Update is called once per frame
    void Update()
    {
        //process inputs, update based on FPS
        ProcessSprint();
        if(hp < maxHp && hp != 0f) {
            RegenHealth();
        }
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

    private void OnCollisionEnter2D(Collision2D hitInfo) {
        if (hitInfo.gameObject.tag == "Enemy")
        {
            ReduceHp(50f);
            if (hp <= 0f) {
                Application.Quit();
            }
        }
    }

    public void ReduceHp(float amount) {
        hp = hp - amount;
        if (hp < 0f) {
            hp = 0f;
        }
        healthBar.SetHealth(hp);
    }

    public void RestoreHp(float amount) {
        hp = hp + amount;
        if (hp > maxHp) {
            hp = maxHp;
        }
        healthBar.SetHealth(hp);
    }

    public void SetMaxHp(float maxHp) {
        this.maxHp = maxHp;
        hp = maxHp;
    }

    private void RegenHealth() {
        while(hp < maxHp) {
            RestoreHp(10f*Time.deltaTime);
        }
    }
}
