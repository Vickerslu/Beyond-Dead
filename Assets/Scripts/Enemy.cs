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

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        moveSpeed = UnityEngine.Random.Range(1,4f);
        hasDropFunc();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed*Time.deltaTime);
    }

    private void hasDropFunc() {
        int rand = UnityEngine.Random.Range(1,1);
        if(rand == 1) {
            hasDrop = true;
        }
    }

    public void TakeDamage(int damage)
    {
        ReduceHp(damage);
        // Debug.Log("took " + damage + " damage, " + hp + " health left");
        if (hp <= 0)
        {
            if(hasDrop) {
                Instantiate(part, transform.position, Quaternion.identity);
                Debug.Log("Dropped!");
            }
            Destroy(gameObject);
            Score.score += 50;
        }
    }

    public void IncreaseHealth(int multiplier)
    {
        hp = Convert.ToInt32(Math.Floor(150*(multiplier*0.5f)));
    }

    public void ReduceHp(int amount) {
        hp -= amount;
        if (hp < 0) {
            hp = 0;
        }
    }

    public void RestoreHp(int amount) {
        hp += amount;
        if (hp > maxHp) {
            hp = maxHp;
        }
    }
}
