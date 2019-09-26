using UnityEngine;
using System.Collections;

public class InstantiateSlime : MonoBehaviour {

	public GameObject Slime;
    private float startX = 12f;
    private float newX;
    private float startY = -0.68f;
    public int spawned;
    public int killed;
    GameObject[] Slimes;

	// Use this for initialization
	void Start () {

        spawned = 0;
        killed = 0;
        newX = startX;

        for (int i = 0; i < 4; i++)
        {
			Instantiate (Slime, new Vector2 (newX, startY), Quaternion.identity);
            newX += 3f;
            spawned++;
		}
	}

    void Ejaculate ()
    {
        spawned = 0;
        killed = 0;
        newX = startX;

        for (int i = 0; i < 4; i++)
        {
            Instantiate(Slime, new Vector2(newX, startY), Quaternion.identity);
            newX += 3f;
            spawned++;
        }
    }

    public void Respawn ()
    {
        Slimes = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject Enemy in Slimes)
        {
            Destroy(Enemy);
            spawned = 0;
            killed = 0;
        }

        Ejaculate();
    }
}
