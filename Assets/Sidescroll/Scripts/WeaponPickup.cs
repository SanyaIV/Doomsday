using UnityEngine;
using System.Collections;

public class WeaponPickup : MonoBehaviour
{

    public GameObject WeaponText;
    public AudioClip pickupSound;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.FindWithTag("UIWeapon").GetComponent<DisableScene1Coin>().Show();
            SoundManager.instance.PlaySingle(pickupSound);
            other.GetComponent<PlatformInputs>().weapon = true;
            other.GetComponentInChildren<WeaponTrans>().WeaponOpa(2);
            WeaponText.SetActive(true);
            Destroy(gameObject);
        }
    }
}
