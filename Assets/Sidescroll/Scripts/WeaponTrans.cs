using UnityEngine;
using System.Collections;

public class WeaponTrans : MonoBehaviour
{

    public GameObject Player, Projectile;

    void Start()
    {
        WeaponOpa(1);
    }

    public void WeaponOpa(int WeaponOpaReturn)
    {
        Color WeaponOpacity = GetComponent<SpriteRenderer>().color;

        if (WeaponOpaReturn == 1)
        {
            WeaponOpacity.a = 0f;
            GetComponent<SpriteRenderer>().color = WeaponOpacity;
        }
        else if (WeaponOpaReturn == 2)
        {
            WeaponOpacity.a = 1f;
            GetComponent<SpriteRenderer>().color = WeaponOpacity;
        }
    }

    public void Shoot()
    {
        var instantiatedPrefab = Instantiate(Projectile, new Vector2(transform.position.x + 0.5f * GetComponentInParent<PlatformInputs>().pubfacing, transform.position.y), Quaternion.identity) as GameObject;
        instantiatedPrefab.transform.localScale = new Vector3(1 * GetComponentInParent<PlatformInputs>().pubfacing, 1, 1);
    }
}