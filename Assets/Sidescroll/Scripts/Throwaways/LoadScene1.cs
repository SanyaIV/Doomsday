using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene1 : MonoBehaviour {

    public AudioClip mainMusic;

    public void Start()
    {
        SoundManager.instance.Music(mainMusic);
    }

    public void LoadOnClick()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
