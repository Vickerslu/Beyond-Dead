using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    public int health;
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        moveSpeed = UnityEngine.Random.Range(1,4f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed*Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("took " + damage + " damage, " + health + " health left");
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

    public void IncreaseHealth(int multiplier)
    {
        health = Convert.ToInt32(Math.Floor(health*(multiplier*0.5f)));
        Debug.Log(health);
    }
}
