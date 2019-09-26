using UnityEngine;
using System.Collections;

public class KillEnemy : MonoBehaviour {

	public int health = 2;
    public AudioClip hitSound;

    void OnCollisionEnter2D (Collision2D gameObject) {

		if (gameObject.gameObject.CompareTag("Player")) {

			health--;
            SoundManager.instance.RandomizeSfx(hitSound);

            //Gör så att spelaren flyger upp i luften.
            gameObject.gameObject.GetComponent<PlatformInputs>().rigidBody.velocity = new Vector2(gameObject.gameObject.GetComponent<PlatformInputs>().rigidBody.velocity.x, 7f);

			if (health <= 0) {

                GameObject.FindWithTag("SlimeEjac").GetComponent<InstantiateSlime>().killed++;

                //Sätt damageTimer till 0 så att spelaren inte tar skada när fienden tas bort..
                //gameObject.gameObject.GetComponent<PlayerVariables> ().damageTimer = 0f;
				//Stäng av collider, funkar inte(?)
				GetComponent<Collider2D> ().enabled = false;
				//Skicka funktionen att objectets förälder skall dö.
				StartCoroutine (transform.parent.gameObject.GetComponent<Enemy> ().Die ());
			}	
		}

        if (gameObject.gameObject.CompareTag("Projectile"))
        {

            health--;
            SoundManager.instance.RandomizeSfx(hitSound);

            if (health <= 0)
            {

                GameObject.FindWithTag("SlimeEjac").GetComponent<InstantiateSlime>().killed++;

                //Sätt damageTimer till 0 så att spelaren inte tar skada när fienden tas bort..
                //gameObject.gameObject.GetComponent<PlayerVariables> ().damageTimer = 0f;
                //Stäng av collider, funkar inte(?)
                GetComponent<Collider2D>().enabled = false;
                //Skicka funktionen att objectets förälder skall dö.
                StartCoroutine(transform.parent.gameObject.GetComponent<Enemy>().Die());
            }
        }
    }

    public void Die()
    {
        GetComponent<Collider2D>().enabled = false;
    }
}
