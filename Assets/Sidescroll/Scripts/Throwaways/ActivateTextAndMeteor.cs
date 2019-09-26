using UnityEngine;
using System.Collections;

public class ActivateTextAndMeteor : MonoBehaviour
{

    public GameObject textGO;
    public bool timer;
    public AudioClip bossMusic;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.FindWithTag("MainCamera").GetComponent<CameraFollow>().boss = true;
            other.GetComponent<PlayerVariables>().deWalk = true;
            other.GetComponent<PlatformInputs>().enabled = false;
            other.GetComponentInChildren<AudioSource>().enabled = false;
            SoundManager.instance.efxSource.Stop();
            SoundManager.instance.jetPackSource.Stop();
            SoundManager.instance.musicSource.Stop();
            SoundManager.instance.Music(bossMusic);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !timer)
        {
            textGO.SetActive(true);
            timer = true;
        }

        if (other.CompareTag("Player") && !timer)
        {
            other.GetComponentInChildren<AudioSource>().enabled = false;
        }

        if (other.CompareTag("Player") && Input.GetKey("e"))
        {
            textGO.SetActive(false);
            other.GetComponent<PlayerVariables>().deWalk = false;
            other.GetComponent<PlatformInputs>().enabled = true;
            Destroy(gameObject);
        }

    }
}