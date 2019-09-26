using UnityEngine;
using System.Collections;

public class HUDScene2 : MonoBehaviour
{

    public CanvasGroup canvasGroup;

    // Use this for initialization
    void Start()
    {
        Hide();
    }

    void Hide()
    {
        canvasGroup.alpha = 0.30f; //this makes everything transparent
    }

    public void Show()
    {
        canvasGroup.alpha = 1f;
    }
}