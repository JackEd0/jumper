using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    /*
    mass: 1
    linear drag: 0
    angular drag: 0.05
    gravity scale: 0.58, 0.8, 2
    velocity: 12
    check radius: 0.5
    extra jump: 1
    */
    public float velocity = 1;
    private Rigidbody2D rb;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatisGround;
    private int extraJumps;
    public int extraJumpsValue = 1;
    public float initialX;

    public Transform firePoint;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        extraJumps = extraJumpsValue;
        initialX = rb.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatisGround);

        // Debug.Log(isGrounded);
        // Debug.Log(extraJumps);
        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }
        // if (Input.GetMouseButtonDown(0))
        // if (Input.GetAxisRaw("Vertical") == 1)
        // if (Input.GetAxis("Vertical") > 0)
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        // else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true)
        // {
        //     Jump();
        // }
        ResetXPosition();

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.S))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        // bullet
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            HealthDisplay.instance.AddScore(1);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            HealthDisplay.instance.SubstractHealth(1);
            HealthDisplay.instance.AddEnemyKilled();
        }
        if (other.gameObject.CompareTag("Health"))
        {
            Destroy(other.gameObject);
            if (HealthDisplay.instance.IsMaxHealth())
            {
                HealthDisplay.instance.AddScore(1);
            } else {
                HealthDisplay.instance.AddHealth(1);
            }

        }
    }

    private void ResetXPosition()
    {
        // Debug.Log(rb.position.x);
        if (rb.position.x != initialX)
        {
            // rb.position.x = initialX;
            rb.position = new Vector2(initialX, rb.position.y);
        }
        // rb.position.x < 0
        // rb.velocity = new Vector2(0.2f, 1) * velocity;
    }
    // private void OnTriggerEnter2D(Collider2D other) {
    //     if (other.gameObject.CompareTag("Coin"))
    //     {
    //         Destroy(other.gameObject);
    //     }
    // }

    public void Jump()
    {
        if (extraJumps > 0 || (extraJumps == 0 && isGrounded == true))
        {
            rb.velocity = Vector2.up * velocity;
            // rb.velocity = new Vector2(0.2f, 1) * velocity;
            // rb.velocity = new Vector2(1, Vector2.up * velocity);
            if (extraJumps > 0)
            {
                extraJumps--;
            }
        }

    }
}
