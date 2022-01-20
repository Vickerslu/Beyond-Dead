using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 50f;
    public int damage;
    public float force = 10f; //how far the bullet pushes back
    public Rigidbody2D rb;

    void Update(){
        transform.Translate(transform.right * speed * Time.deltaTime, Space.World);
    }

    // Deals with what happens when a bullet collides with an enemy
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // possibly the lowest IQ 'if' statement ive ever written to be honest
        if (hitInfo.gameObject.tag != "Player" && hitInfo.gameObject.tag != "Bullet" && hitInfo.gameObject.tag != "Part" && hitInfo.gameObject.tag != "Trigger")
        {
            Enemy enemy = hitInfo.GetComponent<Enemy>();
            if (enemy!= null)
            {
                enemy.TakeDamage(damage);
                Score.score += 5;
            }
            else {
                Destroy(gameObject);
            }
        }
    }
}
