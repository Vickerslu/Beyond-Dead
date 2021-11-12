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

    private void OnCollisionEnter2D(Collision2D hitInfo) {
        if (hitInfo.gameObject.tag == "Enemy")
        {
             ReduceHp(25f);
        }
        if (hitInfo.gameObject.tag == "Ship") {
            if(parts >= 5) {
                Ship.Repair(parts);
                ChangeParts(-parts);
                Debug.Log("Added parts");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log("Collision");
        if (hitInfo.gameObject.tag == "Part") {
            ChangeParts(5);
            Destroy(hitInfo.gameObject);
        }
    }

    public void ChangeParts(int amount) {
        parts += amount;
        PartText.parts += amount;
    }

    public void ReduceHp(float amount) {
        hp = hp - amount;
        if (hp < 0f) {
            hp = 0f;
            SceneManager.LoadScene(2);
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

    IEnumerator RegenHealth() {
        regeningHp = true;
        while(hp < maxHp) {
            RestoreHp(3f);
            yield return new WaitForSeconds(1);
        }
        regeningHp = false;
    }
}
