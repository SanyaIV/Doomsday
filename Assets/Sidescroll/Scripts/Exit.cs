using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Exit : MonoBehaviour {

	public GameObject enemy, lockred, textGO;
    public GameObject[] projectiles;

    void Update (){
		if (enemy.GetComponent<InstantiateSlime> ().killed >= enemy.GetComponent<InstantiateSlime>().spawned) {
			lockred.SetActive (false);
		} else {
			lockred.SetActive (true);
		}
	}

	void OnTriggerEnter2D (Collider2D other) {

		if(other.CompareTag("Player")) {

			if (enemy.GetComponent<InstantiateSlime>().killed >= enemy.GetComponent<InstantiateSlime>().spawned) {
                //other.gameObject.SetActive (false);
                projectiles = GameObject.FindGameObjectsWithTag("Projectile");
                foreach(GameObject Projectile in projectiles)
                {
                    Destroy(Projectile);
                }
                textGO.SetActive(true);
                other.GetComponent<PlatformInputs>().PlayOpa(1);
                other.GetComponentInChildren<WeaponTrans>().WeaponOpa(1);
                other.GetComponent<PlatformInputs>().enabled = false;
                other.GetComponentInChildren<AudioSource>().enabled = false;

                SceneManager.LoadScene (2);
			}
		}
	}
}

