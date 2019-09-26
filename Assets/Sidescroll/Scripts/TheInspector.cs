using UnityEngine;
using System.Collections;

public class TheInspector : MonoBehaviour
{
    public AudioClip moahaha;
    public AudioSource efxSource;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            efxSource.clip = moahaha;
            efxSource.Play();
        }
    }
}