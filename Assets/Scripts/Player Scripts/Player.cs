using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float hp;
    public float maxHp = 100f;

    // stored here because zombie sounds play when the player is hit
    [SerializeField] public AudioClip[] zombieSound;

    // health and stamina variables
    public HealthBar healthBar;
    public StaminaBar staminaBar;
    public bool regeningHp = false;
    public float hpRegenRate = 5f;

    // how many parts the player is holding
    public int parts = 0;

    public bool isShooting;

    // variables for when the player is hit by a zombie
    [SerializeField] private float invincibilityDurationSeconds;
    private bool isInvinsible;
    private bool isKnockedBack;
    private Rigidbody2D rb;

    public bool hasDoubleTapPerk = false;

    void Awake()
    {
        isInvinsible = false;
        rb = GetComponent<Rigidbody2D>();
        hp = maxHp;
        healthBar.SetMaxHealth(maxHp);
    }

    // always regen hp when below max hp
    void Update()
    {
        if(hp != maxHp && !regeningHp) {
            StartCoroutine(RegenHealth());
        }
    }

    // If the player collides with the ship, add their parts to it to repair it
    private void OnCollisionEnter2D(Collision2D hitInfo) {
        if (hitInfo.gameObject.tag == "Ship") {
            if(parts >= 5) {
                Ship.Repair(parts);
                ChangeParts(-parts);
            }
        }
    }

    // If the player triggers a part, add that part to the players 'inventory' and destroy it from the scene
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
        if(isInvinsible) return;
        hp = hp - amount;
        if (hp < 1f) {
            hp = 0f;
            SceneManager.LoadScene("GameOver");
        }
        healthBar.SetHealth(hp);
        //plays random sound when player is hit from array of sounds
        SoundManager.Instance.PlaySound(zombieSound[UnityEngine.Random.Range(0,zombieSound.Length)]);
        StartCoroutine(BecomeInvinsible());
    }

    // Reference: https://www.aleksandrhovhannisyan.com/blog/invulnerability-frames-in-unity/#1-make-the-player-invulnerable-start-the-coroutine
    // makes the player immune to attacks for a set number of seconds
    private IEnumerator BecomeInvinsible() {
        isInvinsible = true;
        yield return new WaitForSeconds(invincibilityDurationSeconds);
        isInvinsible = false;
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

    // Coroutine that regenerates the players health every second by 10hp
    IEnumerator RegenHealth() {
        regeningHp = true;
        while(hp < maxHp) {
            RestoreHp(hpRegenRate);
            yield return new WaitForSeconds(1);
        }
        regeningHp = false;
    }

    // Reference: https://www.youtube.com/watch?v=ahadN8aGvXg
    // Takes the duration of the knockback, how far the player should be pushed, and the object doing the pushing,
    // and knocks the player bac in the opposite direction to the momentum of the object
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

    // extends the players health bar for a visual prompt. increases their max hp by 50%,
    public void AssignHealthPerk() {
        healthBar.ExtendBar();
        maxHp = maxHp*1.5f;
        healthBar.SetMaxHealth(maxHp);
        healthBar.SetHealth(maxHp);
    }

    // extends the players health bar. found a better way to manage stamina inside the stamina bar script, should have done the same for health bar
    public void AssignStaminaPerk() {
        staminaBar.ExtendBar();
    }

    // simply sets a boolean to true, which will be checked when the player fires their gun
    public void AssignDoubleTapPerk() {
        hasDoubleTapPerk = true;
    }

    // increases the rate at which the player regnerates hp by 50%
    public void AssignHpRegenPerk() {
        hpRegenRate = hpRegenRate*1.5f;
    }
}
