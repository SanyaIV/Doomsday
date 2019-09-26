using UnityEngine;
using System.Collections;

public class Speedup : MonoBehaviour {
    
	//private float startSpeed;
	private float startHeight;
	private bool active = true;
    public AudioClip drinkSound;

    IEnumerator OnTriggerEnter2D (Collider2D other) {
		if(other.CompareTag("Player") && active) {
            SoundManager.instance.RandomizeSfx(drinkSound);
            active = false;
            Color jarOpacity = GetComponent<SpriteRenderer>().color;
            jarOpacity.a = 0.2f;
            GetComponent<SpriteRenderer>().color = jarOpacity;
			//startSpeed = 19f; // Här bör vi ändra på speed under other.GetComponent<PlatformInputs>() till att t.ex. vara sig själv * 1.5f;
			startHeight = 19f;
			//other.GetComponent<PlatformInputs> ().speed = startSpeed;
			other.GetComponent<PlatformInputs> ().jumpHeight = startHeight;
			yield return new WaitForSeconds(3f);
			//startSpeed = 10f;
			startHeight = 10f;
			//other.GetComponent<PlatformInputs>().speed=startSpeed;
			other.GetComponent<PlatformInputs> ().jumpHeight = startHeight;
			active = true;
            jarOpacity.a = 1;
            GetComponent<SpriteRenderer>().color = jarOpacity;
        }
	}
}
