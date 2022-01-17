using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class Enemy : MonoBehaviour
{
    // [SerializeField] private float moveSpeed;
    // [SerializeField] private GameObject player;

    public Animator animator;

    public bool hasDrop;
    public Part part;

    public int maxHp;
    public int hp;

    [SerializeField] GameObject target;
    public NavMeshAgent agent;

    public static int dropRate = 100;
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
        agent.SetDestination(target.transform.position);
        //amimation
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
            Score.score += 5;
        }
    }

    // Takes an integer and reduces the enemies health by this amount.
    public void ReduceHp(int amount) {
        hp = hp - amount;
        Debug.Log("Damage Taken: " + amount + "Hp: " + hp);
        if (hp < 0) {
            hp = 0;
        }
    }

    protected virtual void OnCollisionEnter2D(Collision2D hitInfo) {
        if (hitInfo.gameObject.tag == "Player")
        {
            Player player = hitInfo.gameObject.GetComponent<Player>();
            player.Knockback(knockbackDuration, knockbackPower, this.transform);
            DealDamage(player);
        }
    }

    public virtual void DealDamage(Player player) {
        player.ReduceHp(25f);
    }

    // Takes an integer and uses this integer in a formula to scale up the enemies health.
    public virtual void IncreaseHealth(int multiplier) {
        maxHp = Convert.ToInt32(maxHp+(10*multiplier));
        hp = maxHp;
        Debug.Log("Spawned with Hp: " + hp);
    }
}
