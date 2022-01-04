using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 50f;
    public int damage = 70;
    public Rigidbody2D rb;

    void Update(){
        transform.Translate(transform.right * speed * Time.deltaTime, Space.World);
    }

    // Deals with what happens when a bullet collides with something. Ignores if it is another bullet or the player.
    // If it hits an enemy, deal damage to that enemy and increase the score. Remove the bullet in this case.
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag != "Player" && hitInfo.gameObject.tag != "Bullet" && hitInfo.gameObject.tag != "Part")
        {
            Enemy enemy = hitInfo.GetComponent<Enemy>();
            if (enemy!= null)
            {
                enemy.TakeDamage(damage);
                Score.score += 10;
            }
            else {
                Destroy(gameObject);
            }
        }
    }
}
