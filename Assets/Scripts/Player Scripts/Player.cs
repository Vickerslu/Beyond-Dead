using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Reference: https://www.youtube.com/watch?v=u8tot-X_RBI&t=1s&ab_channel=BMo
public class Player : MonoBehaviour
{
    public float hp;
    public float maxHp = 100f;

    [SerializeField] public AudioClip[] zombieSound;

    public HealthBar healthBar;
    public StaminaBar staminaBar;
    public bool regeningHp = false;
    public float hpRegenRate = 5f;

    public int parts = 0;

    public bool isShooting;

    private bool isKnockedBack;
    private Rigidbody2D rb;

    public bool hasDoubleTapPerk = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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
        if (hitInfo.gameObject.tag == "Room") {
            Transform parent = hitInfo.gameObject.transform;
            parent.GetChild(0).gameObject.SetActive(true);
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
        if (hp < 1f) {
            hp = 0f;
            SceneManager.LoadScene("GameOver");
        }
        healthBar.SetHealth(hp);
        //plays random sound when player is hit from array of sounds
        SoundManager.Instance.PlaySound(zombieSound[UnityEngine.Random.Range(0,zombieSound.Length)]);
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
            RestoreHp(hpRegenRate);
            yield return new WaitForSeconds(1);
        }
        regeningHp = false;
    }

    // https://www.youtube.com/watch?v=ahadN8aGvXg
    public void Knockback(float duration, float power, Transform obj) {
        if(!isKnockedBack) {
            isKnockedBack = true;
            float timer = 0;
            while(duration > timer) {
                timer += Time.deltaTime;
                Vector2 direction = (obj.transform.position - this.transform.position).normalized;
                rb.AddForce(-direction * power);
            }
            isKnockedBack = false;
        }
    }

    // Perk Methods
    public void AssignHealthPerk() {
        healthBar.ExtendBar();
        maxHp = maxHp*1.5f;
        healthBar.SetMaxHealth(maxHp);
        healthBar.SetHealth(maxHp);
    }

    public void AssignStaminaPerk() {
        staminaBar.ExtendBar();
    }

    public void AssignDoubleTapPerk() {
        hasDoubleTapPerk = true;
    }

    public void AssignHpRegenPerk() {
        hpRegenRate = hpRegenRate*1.5f;
    }
}
