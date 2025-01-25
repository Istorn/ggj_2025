using System.Collections;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public CanvasGroup blackoutCanvas;
    public float transitionTime;
    public bool isGameOver;

    // Reference to the ControllerNavigationWithActions script
    public ControllerNavigationWithActions controllerNavigation;

    public void met_BlackoutOff()
    {
        blackoutCanvas.alpha = 0f;
        blackoutCanvas.blocksRaycasts = false;
        blackoutCanvas.interactable = false;

        // Disable controller navigation when blackout is off
        if (controllerNavigation != null)
        {
            controllerNavigation.enabled = false;
        }
    }

    public void met_GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            met_BlackoutSetup();
            StartCoroutine(ien_Blackout());
        }
    }

    void met_BlackoutSetup()
    {
        blackoutCanvas.alpha = 0f;
        blackoutCanvas.blocksRaycasts = true;
        blackoutCanvas.interactable = true;

        // Disable controller navigation during blackout setup
        if (controllerNavigation != null)
        {
            controllerNavigation.enabled = false;
        }
    }

    IEnumerator ien_Blackout()
    {
        float elapsedTime = 0;
        while (elapsedTime < transitionTime)
        {
            blackoutCanvas.alpha = Mathf.Lerp(blackoutCanvas.alpha, 1f, elapsedTime / transitionTime);
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        // Activate controller navigation after blackout is complete
        if (controllerNavigation != null)
        {
            controllerNavigation.enabled = true;
        }
    }
}
