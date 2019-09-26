using UnityEngine;
using System.Collections;

public class Meteor : MonoBehaviour {

    public Collider2D[] myColliders;

    void Start()
    {
        myColliders = gameObject.GetComponents<Collider2D>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerVariables>().Harm(51f);

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var force = other.transform.position - transform.position;
            force.Normalize();
            other.GetComponent<PlatformInputs>().rigidBody.velocity = new Vector2(7f * force.x, 7f);

            other.GetComponent<PlayerVariables>().Harm(51f);
        }
    }

    public void Disable()
    {
        foreach (Collider2D bc in myColliders) bc.enabled = false;
    }
}
