using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

// An enemy is anything that attacks the player
public class Enemy : MonoBehaviour
{
    // particle related
    public GameObject blood;
    public GameObject bloodHit;
    public Animator animator;

    // if it hasDrop, it will drop a part when killed
    public bool hasDrop;
    public Part part;

    public int maxHp;
    public int hp;

    // 'target' will be the player. Neccessary to set these up for nav mesh navigation
    [SerializeField] GameObject target;
    public NavMeshAgent agent;

    // 'drop rate' equates mathematically to the average amount of zombies needed to kill to get 5 parts
    public static int dropRate = 25;
    public static float speedMultiplier = 1; //gets overridden by zombie speed slider

    protected float knockbackPower;
    protected float knockbackDuration;

    protected virtual void Start()
    {
        knockbackPower = 1f;
        knockbackDuration = 3f;
        hasDropFunc();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = speedMultiplier * UnityEngine.Random.Range(5f,6f);
        target = GameObject.Find("Player");
    }

    protected virtual void Update()
    {
        // travels toward the player's position through the nav mesh
        agent.SetDestination(target.transform.position);
        //sets the amimation variables
        //so it change to different animations
        if(agent.speed > 0.01) {
            animator.SetFloat ("Speed", (float)1.00);
            animator.SetFloat ("Horizontal", (float)target.transform.position.x);
            animator.SetFloat ("Vertical", (float)target.transform.position.y);
        }
        else {
            animator.SetFloat ("Speed", (float)0.00);
        }
    }

    // Decides whether the enemy drops something upon death randomly.
    private void hasDropFunc() {
        int rand = UnityEngine.Random.Range(1,dropRate);
        if(rand == 1) {
            hasDrop = true;
        }
    }

    // Takes an integer and decreases the enemies health by this amount.
    // If they have a drop, drop this upon death if their health hits 0. Increase score.
    public void TakeDamage(int damage)
    {
        ReduceHp(damage);
        if (hp <= 0)
        {
            if(hasDrop) {
                Instantiate(part, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
            //when the zombie dies blood splatter is called
            Instantiate(blood, transform.position, Quaternion.identity);
            Score.score += 10;
        }
    }

    // Takes an integer and reduces the enemies health by this amount.
    public void ReduceHp(int amount) {
        hp = hp - amount;
        //each bullet hit that causes damage will create a little blood
        Instantiate(bloodHit, transform.position, Quaternion.identity);
        if (hp < 0) {
            hp = 0;
        }
    }

    // if the enemy collides with the player, knock them back and deal damage to them
    protected virtual void OnCollisionEnter2D(Collision2D hitInfo) {
        if (hitInfo.gameObject.tag == "Player")
        {
            Player player = hitInfo.gameObject.GetComponent<Player>();
            player.Knockback(knockbackDuration, knockbackPower, this.transform);
            DealDamage(player);
        }
    }

    // deal damage to the player
    public virtual void DealDamage(Player player) {
        player.ReduceHp(25f);
    }

    // Takes an integer and uses this integer in a formula to scale up the enemies health. (multiplier is 1 by default, but can be changed in the settings)
    public virtual void IncreaseHealth(int multiplier) {
        maxHp = Convert.ToInt32(maxHp+(10*multiplier));
        hp = maxHp;
    }
}
