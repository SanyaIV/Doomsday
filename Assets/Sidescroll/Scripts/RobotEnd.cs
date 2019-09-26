using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RobotEnd : MonoBehaviour
{

    void Update()
    {
        //GameObject.FindWithTag("Player").GetComponent<PlatformInputs>().enabled = false;
        //GameObject.FindWithTag("Player").GetComponent<PlayerVariables>().deWalk = true;

        if (Input.GetKeyDown("e"))
        {
            Destroy(GameObject.FindWithTag("Player"));
            Destroy(GameObject.FindWithTag("MainCamera"));
            Destroy(GameObject.FindWithTag("SoundManager"));
            SceneManager.LoadScene(0);
        }

    }
}