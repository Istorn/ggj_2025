using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public CanvasManager canvasManager;
    private void Start()
    {
        canvasManager.met_BlackoutOff();
    }
    public void met_GameOver()
    {
        canvasManager.met_GameOver();
    }
}
