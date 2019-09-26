using UnityEngine;
using System.Collections;

public class InstantiatePlayer : MonoBehaviour
{

    public GameObject Player;
    private float startX = 0f;
    private float startY = 0f;
    public int spawned = 0;

    // Use this for initialization
    void Start()
    {
        if (spawned <= 0)
        {
            Instantiate(Player, new Vector2(startX, startY), Quaternion.identity);
            spawned++;
        }
        
    }
}
