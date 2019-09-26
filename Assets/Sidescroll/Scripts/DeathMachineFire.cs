using UnityEngine;
using System.Collections;

public class DeathMachineFire : MonoBehaviour {

    public int hits = 2;
    public AudioClip fireSound;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var force = other.transform.position - transform.position;
            force.Normalize();
            other.GetComponent<PlatformInputs>().rigidBody.velocity = new Vector2(7f * force.x, 7f);
            other.GetComponent<PlayerVariables>().Harm(20);
        }

        if (other.CompareTag("Projectile"))
        {
            hits--;
            if (hits <= 0)
            {
                SoundManager.instance.PlaySingle(fireSound);
                GetComponentInParent<DeathMachine>().fires--;
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var force = other.transform.position - transform.position;
            force.Normalize();
            other.GetComponent<PlatformInputs>().rigidBody.velocity = new Vector2(7f * force.x, 7f);
            other.GetComponent<PlayerVariables>().Harm(20);
        }
    }
}
