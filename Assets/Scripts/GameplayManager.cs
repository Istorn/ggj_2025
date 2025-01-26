using Unity.VisualScripting;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    CanvasManager canvasManager;
    spawnObject objectSpawner;
    PointsManager pointsManager;
    spawnPlayer spawnPlayer;

    private void Start()
    {
        canvasManager = GetComponent<CanvasManager>();
        objectSpawner = GetComponent<spawnObject>();
        pointsManager = GetComponent<PointsManager>();
        spawnPlayer = FindObjectOfType<spawnPlayer>();

        canvasManager.met_BlackoutOff();
        spawnPlayer.met_StartGame();
    }
    public void met_GameOver()
    {
        objectSpawner.isSpawningBonus = false;
        pointsManager.met_GameOver();
        canvasManager.met_GameOver();
    }
}
