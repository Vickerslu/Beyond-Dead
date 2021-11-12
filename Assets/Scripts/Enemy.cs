using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject player;

    public bool hasDrop;
    public Part part;

    public int maxHp;
    public int hp;

    void Start()
    {
        player = GameObject.Find("Player");
        moveSpeed = UnityEngine.Random.Range(5,5f);
        hasDropFunc();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed*Time.deltaTime);
    }

    // Decides whether the enemy drops something upon death randomly.
    private void hasDropFunc() {
        int rand = UnityEngine.Random.Range(1,5);
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

    // Takes an integer and uses this integer in a formula to scale up the enemies health.
    public void IncreaseHealth(int multiplier)
    {
        hp = Convert.ToInt32(Math.Floor(150*(multiplier*0.3f)));
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
