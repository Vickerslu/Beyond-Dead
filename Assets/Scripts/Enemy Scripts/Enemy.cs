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
    [SerializeField] public AudioClip ZombieAudio;

    public bool hasDrop;
    public Part part;

    [SerializeField] protected int maxHp;
    protected int hp;

    [SerializeField] GameObject target;
    public NavMeshAgent agent;

    public static int dropRate = 5;
    public static float speedMultiplier = 1; //gets overridden by zombie speed slider

    protected virtual void Start()
    {
        hasDropFunc();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = speedMultiplier * UnityEngine.Random.Range(4f,5f);
        target = GameObject.Find("Player");
        Debug.Log("Drop rate: " + dropRate);
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
            Score.score += 50;
        }
    }

    protected virtual void OnCollisionEnter2D(Collision2D hitInfo) {
        if (hitInfo.gameObject.tag == "Player")
        {
            Player player = hitInfo.gameObject.GetComponent<Player>();
            DealDamage(player);
            SoundManager.Instance.PlaySound(ZombieAudio);
        }
    }

    public virtual void DealDamage(Player player) {
        player.ReduceHp(50f);
    }

    // Takes an integer and uses this integer in a formula to scale up the enemies health.
    public virtual void IncreaseHealth(int multiplier) {
        hp = Convert.ToInt32(Math.Floor(300*(multiplier*0.3f)));
    }

    // Takes an integer and reduces the enemies health by this amount.
    public void ReduceHp(int amount) {
        hp -= amount;
        if (hp < 0) {
            hp = 0;
        }
    }

    // Takes an integer and increases their hp by this amount.
    public void RestoreHp(int amount) {
        hp += amount;
        if (hp > maxHp) {
            hp = maxHp;
        }
    }
}
