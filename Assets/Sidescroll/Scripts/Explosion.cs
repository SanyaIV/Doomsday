using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

    private float Timer;
    public GameObject Robot;
    private bool Instantiated;
    private GameObject[] meteor;
    private bool meteorDestroyed = false;
    public AudioClip explosionSound;

	void Update ()
    {
        Timer += Time.deltaTime;

        if (!meteorDestroyed)
        {
            SoundManager.instance.PlaySingle(explosionSound);
            Destroy(GameObject.Find("MeteorShower"));
            meteor = GameObject.FindGameObjectsWithTag("Meteor");
            foreach (GameObject Meteor in meteor)
            {
                Meteor.GetComponent<Meteor>().Disable();
            }
            meteorDestroyed = true;
        }

        if (Timer >= 2)
        {
            Destroy(GameObject.Find("Death_Machine"));
            Destroy(GameObject.Find("the_inspector"));
            GameObject.FindWithTag("Player").GetComponent<PlayerVariables>().health = 1f;
            meteor = GameObject.FindGameObjectsWithTag("Meteor");

            if (!Instantiated)
            {
                Instantiate(Robot, new Vector2(129.5f, -1.55f), Quaternion.identity);
                Instantiated = true;
            }
            
        }
        if (Timer >= 4)
        {
            Destroy(gameObject);
        }
	}
}
