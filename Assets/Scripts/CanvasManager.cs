using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public CanvasGroup blackoutCanvas;
    public float transitionTime;
    private void Start()
    {
        met_BlackoutOff();
    }
    public void met_BlackoutOff()
    {
        blackoutCanvas.alpha = 0f;
        blackoutCanvas.blocksRaycasts = false;
        blackoutCanvas.interactable = false;
    }

    void met_BlackoutSetup()
    {
        blackoutCanvas.alpha = 0f;
        blackoutCanvas.blocksRaycasts = true;
        blackoutCanvas.interactable = true;
    }
    public void met_StartBlackout()
    {
        met_BlackoutSetup();
        StartCoroutine(ien_Blackout());
    }
    IEnumerator ien_Blackout()
    {
        while (blackoutCanvas.alpha <1f)
        {
            // blackoutCanvas.alpha
        }
        yield return new WaitForEndOfFrame();
    }
}
