using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Reference: https://www.youtube.com/watch?v=u8tot-X_RBI&t=1s&ab_channel=BMo
public class Player : MonoBehaviour
{
    public float hp;
    public float maxHp = 100f;

    public HealthBar healthBar;
    public bool regeningHp = false;

    public int parts = 0;

    void Awake() 
    {
        hp = maxHp;
        healthBar.SetMaxHealth(maxHp);
    }    

    void Update()
    {
        if(hp != maxHp && !regeningHp) {
            StartCoroutine(RegenHealth());
        }
    }

    // Deals with collisions - specifically player collisions with enemies and the ship
    private void OnCollisionEnter2D(Collision2D hitInfo) {
        // if (hitInfo.gameObject.tag == "Enemy")
        // {
        //      ReduceHp(25f);
        // }
        if (hitInfo.gameObject.tag == "Ship") {
            if(parts >= 5) {
                Ship.Repair(parts);
                ChangeParts(-parts);
            }
        }
    }

    // Deals with triggers - specifically triggers associated with parts
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag == "Part") {
            ChangeParts(5);
            Destroy(hitInfo.gameObject);
        }
    }

    // Takes an integer and increases the amount of parts the player has in their inventory by this amount.
    // Also updates the on-screen parts text
    public void ChangeParts(int amount) {
        parts += amount;
        PartText.parts += amount;
    }

    // Takes a float, and decreases the players hp by this amount. Deals with what happens if the players hp hits 0.
    // Also updates the on-screen health bar
    public void ReduceHp(float amount) {
        hp = hp - amount;
        if (hp < 0f) {
            hp = 0f;
            SceneManager.LoadScene(2);
        }
        
        healthBar.SetHealth(hp);
    }

    // Takes a float, and increases the players hp by this amount. Deals with what happens if the players hp hits its max.
    // Also updates the on-screen health bar
    public void RestoreHp(float amount) {
        hp = hp + amount;
        if (hp > maxHp) {
            hp = maxHp;
        }
        healthBar.SetHealth(hp);
    }

    // Coroutine that regenerates the players health every second by 10
    IEnumerator RegenHealth() {
        regeningHp = true;
        while(hp < maxHp) {
            RestoreHp(10f);
            yield return new WaitForSeconds(1);
        }
        regeningHp = false;
    }


    // Perk Methods
    public void AssignHealthPerk() {
        healthBar.ExtendBar();
        maxHp = maxHp*1.5f;
        healthBar.SetMaxHealth(maxHp);
        healthBar.SetHealth(maxHp);
    }
}