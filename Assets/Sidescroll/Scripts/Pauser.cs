using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Pauser : MonoBehaviour {

	private bool paused = false;
    public GameObject Menu;

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                if (!paused)
                {
                    paused = true;
                    Time.timeScale = 0;
                    Show();
                }
                else if (paused)
                {
                    Hide();
                    paused = false;
                    Time.timeScale = 1;
                }
            }
        }
    }

    void Show()
    {
        Menu.SetActive(true);
        Cursor.visible = true;
    }

    void Hide()
    {
        Menu.SetActive(false);
        Cursor.visible = false;
    }

    public void LoadOnClick()
    {
        Hide();
        paused = false;
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
