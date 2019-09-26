using UnityEngine;
using System.Collections;

public class DisableScene1Coin : MonoBehaviour {

    public CanvasGroup canvasGroup;

    // Use this for initialization
    void Start () {
        Hide();
	}

    void Hide()
    {
        canvasGroup.alpha = 0f; //this makes everything transparent
    }

    public void Show()
    {
        canvasGroup.alpha = 1f;
    }
}
