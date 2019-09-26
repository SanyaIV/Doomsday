using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag ("Player")) {

			other.GetComponent<PlayerVariables> ().Respawn ();
			// Spelaren har en funktion som heter Respawn i scriptet PlayerVariables. Anropa denna funktion för att få spelaren att börja om från sin startposition.
		} else if (other.CompareTag ("Enemy")) {
			other.gameObject.SetActive (false);
		} else {
			Destroy (other.gameObject);
		}
	}
}
