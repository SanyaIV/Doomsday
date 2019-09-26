using UnityEngine;
using System.Collections;

public class HealthUp : MonoBehaviour {

    public AudioClip drinkSound;

    void OnTriggerEnter2D (Collider2D other) {
		if(other.CompareTag("Player")){
            other.GetComponent<PlayerVariables>().health = 100f;
            SoundManager.instance.RandomizeSfx(drinkSound);
			Destroy (gameObject);
		}
	}
}
