using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform target;
    public bool boss = false;
    public float StatX = 111f;

    void Awake ()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

	void LateUpdate () {
		if (target.position.y >= -1.9 && SceneManager.GetActiveScene().buildIndex != 2) {
			transform.position = Vector3.Lerp (transform.position, new Vector3 (target.position.x, /*target.position.y+*/5f, transform.position.z), Time.deltaTime * 3f);
			GetComponent<Camera> ().orthographicSize = 8.5f;
		} else if (target.position.y < -1.9 && SceneManager.GetActiveScene().buildIndex != 2) {
			transform.position = Vector3.Lerp (transform.position, new Vector3 (target.position.x, target.position.y + 5f, transform.position.z), Time.deltaTime * 3f);
			GetComponent<Camera> ().orthographicSize = 8.5f + target.position.y * 0.2f;
		}
        else if (target.position.y >= -1.9 && !boss)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, /*target.position.y+*/9.45f, transform.position.z), Time.deltaTime * 3f);
            GetComponent<Camera>().orthographicSize = 13f;
        }
        else if (target.position.y < -1.9 && !boss)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y + 9.45f, transform.position.z), Time.deltaTime * 3f);
            GetComponent<Camera>().orthographicSize = 13f + target.position.y * 0.2f;
        } else if (boss)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(StatX, 9.45f, transform.position.z), Time.deltaTime * 2f);
            GetComponent<Camera>().orthographicSize = 13f;
        }
	}
}
