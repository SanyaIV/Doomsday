using UnityEngine;
using System.Collections;

public class DeathMachine : MonoBehaviour {

    public int fires = 4;
    public GameObject Explosion;
    private bool Instantiated = false;


	void Update () {
	    if (fires <= 0)
        {
            if (!Instantiated)
            {
                Instantiate(Explosion, new Vector2(126f, 0.33f), Quaternion.identity);
                Instantiated = true;
            }
        }
	}
}
