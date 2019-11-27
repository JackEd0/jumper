using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    private Rigidbody2D rb;
    public GameObject bulletImpact;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 0.5f);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            HealthDisplay.instance.AddScore(1);
            HealthDisplay.instance.AddEnemyKilled();
        }
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            HealthDisplay.instance.AddScore(1);
        }

        GameObject newImpact = Instantiate(bulletImpact, transform.position, transform.rotation);
        Destroy(newImpact, 0.3f);
        Destroy(gameObject);
    }
}
