using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 50f;
    public int damage = 30;
    public Rigidbody2D rb;

    void Update(){
        transform.Translate(transform.right * speed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag != "Player" && hitInfo.gameObject.tag != "Bullet")
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
