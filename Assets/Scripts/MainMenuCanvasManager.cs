using UnityEngine;
using System.Collections;

public class MainMenuCanvasManager : MonoBehaviour
{
    public CanvasGroup mainMenuCanvas;
    public CanvasGroup playerSelectionCanvas;
    public float transitionTime;

    // Start is called before the first frame update
    void Start()
    {
        met_HideCanvas(playerSelectionCanvas);
        met_ShowCanvas(mainMenuCanvas);
    }

    void met_HideCanvas(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 0f;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;
    }

    void met_ShowCanvas(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 1f;
        
    }

    public void met_StartTransition()
    {
        StartCoroutine(ien_StartTransition(playerSelectionCanvas));
    }

    IEnumerator ien_StartTransition(CanvasGroup canvasGroup)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;

        float elapsedTime = 0;
        while (elapsedTime < transitionTime)
        {
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, 1f, elapsedTime / transitionTime);
            elapsedTime += Time.deltaTime;

            yield return null;
        }
        met_HideCanvas(mainMenuCanvas);
    }
}
