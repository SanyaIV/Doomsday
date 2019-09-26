using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MovePlayerOnStart : MonoBehaviour {

    public AudioClip scene2Music;

    // Use this for initialization
    void Start () {
        Cursor.visible = false;
        GameObject.FindWithTag("Player").GetComponent<PlatformInputs>().enabled = true;
        GameObject.FindWithTag("Player").GetComponent<PlayerVariables>().DoStartPos();
        GameObject.FindWithTag("Player").GetComponent<PlatformInputs>().PlayOpa(2);
        GameObject.FindWithTag("Player").GetComponent<PlayerVariables>().HUDUI();
        GameObject.FindWithTag("Player").GetComponentInChildren<JetpackTrans>().JetOpa(1);
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            GameObject.FindWithTag("Player").GetComponentInChildren<WeaponTrans>().WeaponOpa(2);
            GameObject.FindWithTag("Player").GetComponent<PlatformInputs>().weapon = true;
            SoundManager.instance.musicSource.Stop();
            SoundManager.instance.Music(scene2Music);
        }
        //GameObject.FindWithTag("MainCamera").GetComponent<CameraFollow>().target = GameObject.FindWithTag("Player");
    }
}
