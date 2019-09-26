using UnityEngine;
using System.Collections;

public class InstantiateMeteor : MonoBehaviour
{

    public GameObject Meteor;
    private float startX = 93f;
    private float stopX = 134f;
    private float startY = 30f;
    private float spawnTimer;
    //public bool meteorEnable = false;

    // Use this for initialization
    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= 0.5)
        {
            Instantiate(Meteor, new Vector2(Random.Range(startX, stopX), startY), Quaternion.identity);
            spawnTimer = 0f;
        }
    }
}
