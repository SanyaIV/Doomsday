using UnityEngine;
using System.Collections;

public class InspectorSound : MonoBehaviour
{

    public AudioSource efxSource;
    public AudioClip moahaha;

    void OnTriggerEnter2D(Collider2D other)
    {
        efxSource.clip = moahaha;
        efxSource.Play();
    }
}
