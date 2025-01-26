using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public PointsManager pointsManager;
    public CanvasGroup blackoutCanvas;
    public float transitionTime;
    public bool isGameOver;

    void Start()
{
    if (pointsManager == null)
    {
        pointsManager = GetComponent<PointsManager>();
        if (pointsManager == null)
        {
            Debug.LogError("PointsManager script not found on the same GameObject!");
        }
    }
}

    public void met_BlackoutOff()
    {
        blackoutCanvas.alpha = 0f;
        blackoutCanvas.blocksRaycasts = false;
        blackoutCanvas.interactable = false;
    }
    public void met_GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            // Store new score
            List<int> currentScores= pointsManager.LoadScores("Assets/Resources/scores.txt");

            pointsManager.AddScore(currentScores,pointsManager.getCurrentScore());

            pointsManager.SaveScores("Assets/Resources/scores.txt",currentScores);
            
            met_BlackoutSetup();
            StartCoroutine(ien_Blackout());
        }
    }
    void met_BlackoutSetup()
    {
        blackoutCanvas.alpha = 0f;
        blackoutCanvas.blocksRaycasts = true;
        blackoutCanvas.interactable = true;
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
    }
}
