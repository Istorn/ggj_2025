using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    CanvasManager canvasManager;
    spawnObject objectSpawner;
    PointsManager pointsManager;
    private void Start()
    {
        canvasManager = GetComponent<CanvasManager>();
        objectSpawner = GetComponent<spawnObject>();
        pointsManager = GetComponent<PointsManager>();

        canvasManager.met_BlackoutOff();
    }
    public void met_GameOver()
    {
        canvasManager.met_GameOver();
        objectSpawner.isSpawningBonus = false;
        // Interrompere lo spawn dei bonus
        // Immobilizzare i player e disattivarne le collisioni
    }
}
