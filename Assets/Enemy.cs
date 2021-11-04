using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    private int health = 100;
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed*Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
            Score.score += 50;
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void IncreaseHealth(float multiplier)
    {
        health = Convert.ToInt32(Math.Floor(health+(health*multiplier)));
    }
}
