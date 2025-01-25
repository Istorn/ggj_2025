using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public CanvasManager canvasManager;
    spawnObject objectSpawner;
    private void Start()
    {
        canvasManager.met_BlackoutOff();
        objectSpawner = GetComponent<spawnObject>();
    }
    public void met_GameOver()
    {
        canvasManager.met_GameOver();
        objectSpawner.isSpawningBonus = false;
        // Interrompere lo spawn dei bonus
        // Immobilizzare i player e disattivarne le collisioni
    }
}
