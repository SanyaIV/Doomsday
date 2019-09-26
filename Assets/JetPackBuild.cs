using UnityEngine;
using System.Collections;

public class JetPackBuild : MonoBehaviour {

    public GameObject textGO, textGO2;
    public bool built = false;
    public AudioClip buildSound;

    // Use this for initialization
    void Start () {
        Color JetPack = GetComponent<SpriteRenderer>().color;
        JetPack.a = 0f;
        GetComponent<SpriteRenderer>().color = JetPack;
    }
	
	// Update is called once per frame
	void Update () {
	    if (GameObject.FindWithTag("Player").GetComponent<PlayerVariables>().coins >= 4)
        {
            Color JetPack = GetComponent<SpriteRenderer>().color;
            JetPack.a = 0.5f;
            GetComponent<SpriteRenderer>().color = JetPack;
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.GetComponent<PlayerVariables>().coins >= 4)
        {
            if (!built)
            {
                textGO.SetActive(true);
            }else if (built)
            {
                textGO2.SetActive(true);
            }

            if (Input.GetKey("e") && other.GetComponent<PlayerVariables>().coins >= 4 && !built)
            {
                GameObject.FindWithTag("UIJetpack").GetComponent<HUDScene2>().Show();
                SoundManager.instance.PlaySingle(buildSound);
                other.GetComponent<PlatformInputs>().jetpack = true;
                other.GetComponentInChildren<JetpackTrans>().JetOpa(2);
                built = true;
                textGO.SetActive(false);
                textGO2.SetActive(true);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey("e") && other.GetComponent<PlayerVariables>().coins >= 4 && !built)
            {
                GameObject.FindWithTag("UIJetpack").GetComponent<HUDScene2>().Show();
                SoundManager.instance.PlaySingle(buildSound);
                other.GetComponent<PlatformInputs>().jetpack = true;
                other.GetComponentInChildren<JetpackTrans>().JetOpa(2);
                built = true;
                textGO.SetActive(false);
                textGO2.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!built)
            {
                textGO.SetActive(false);
            }
            else if (built)
            {
                textGO2.SetActive(false);
            }
        }
    }

}
