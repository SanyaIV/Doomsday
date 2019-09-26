using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour {

	public GameObject textGO, TextGO2, enemy;
		
	void OnTriggerEnter2D (Collider2D other) {
		if(other.CompareTag("Player")) {
            if (enemy.GetComponent<InstantiateSlime>().killed < enemy.GetComponent<InstantiateSlime>().spawned)
            {
                textGO.SetActive(true);
            }
            else if (enemy.GetComponent<InstantiateSlime>().killed >= enemy.GetComponent<InstantiateSlime>().spawned)
            {
                TextGO2.SetActive(true);
            }
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if(other.CompareTag("Player")) {
			if (enemy.GetComponent<InstantiateSlime>().killed < enemy.GetComponent<InstantiateSlime>().spawned) {
				textGO.SetActive (false);
			} else if (enemy.GetComponent<InstantiateSlime>().killed >= enemy.GetComponent<InstantiateSlime>().spawned) {
				TextGO2.SetActive (false);
			}
        }
	}

	// Det finns, som ni ser över här, en funktion som heter OnTriggerEnter2D. Det finns även en funktion som heter OnTriggerExit2D. 
	// Skriv en sådan med SetActive(false); för att få skylten att stängas. 

}
