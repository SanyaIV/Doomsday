using UnityEngine;
using System.Collections;

public class JetpackTrans : MonoBehaviour {

    public GameObject Particle, Player;

	void Start () {
        JetOpa(1);
        Particle.SetActive(false);
	}

    void Update ()
    {
        if (Player.GetComponent<PlatformInputs>().jetpack == true && Input.GetKey("space"))
        {
            Particle.SetActive(true);
        }
        else
        {
            Particle.SetActive(false);
        }
    }

    public void JetOpa(int JetOpaReturn)
    {
        Color JetpackOpacity = GetComponent<SpriteRenderer>().color;

        if (JetOpaReturn == 1)
        {
            JetpackOpacity.a = 0f;
            GetComponent<SpriteRenderer>().color = JetpackOpacity;
        }
        else if (JetOpaReturn == 2)
        {
            JetpackOpacity.a = 1f;
            GetComponent<SpriteRenderer>().color = JetpackOpacity;
        }
    }
}
