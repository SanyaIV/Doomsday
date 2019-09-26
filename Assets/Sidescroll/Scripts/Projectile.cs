using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public int speed = 0;
    public Rigidbody2D rb;
    public GameObject player;

    //public PlayerController player;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        rb.velocity = new Vector2(speed * player.GetComponent<PlatformInputs>().pubfacing, rb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        //rb.velocity = new Vector2(speed * player.GetComponent<PlatformInputs>().pubfacing, rb.velocity.y);
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        Destroy(gameObject);
    }
}
