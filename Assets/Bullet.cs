using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag != "Player" && hitInfo.gameObject.tag != "Bullet")
        {
            // Debug.Log(hitInfo.name);
            Enemy enemy = hitInfo.GetComponent<Enemy>();
            if (enemy!= null)
            {
                enemy.TakeDamage(damage);
                Score.score += 10;
            }
            Destroy(gameObject);

            //TODO: call increaseScore() method from Scores.cs, cant seem to do it cuz im retarded :(
        }

        
    }
}
