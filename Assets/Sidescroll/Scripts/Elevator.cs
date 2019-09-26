using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour {

	void OnCollisionEnter2D (Collision2D other) {
		if(other.collider.CompareTag("Player")){
			other.transform.parent = transform;
		}
	}

	void OnCollisionExit2D (Collision2D other) {
		if(other.collider.CompareTag("Player")){
			other.transform.parent = null;
		}
	}
}
