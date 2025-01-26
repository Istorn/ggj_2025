using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    public int punteggioSquadra;
    public Text punti_ui;
    public Text puntiGameOver;
    
    // Start is called before the first frame update
    void Start()
    {
        met_ResetPunti();
    }
    
    public void met_ResetPunti()
    {
        punteggioSquadra = 0;
        punti_ui.text = "0";
    }

    public void met_AggiungiPunti(int puntiDaAggiungere)
    {
        punteggioSquadra += puntiDaAggiungere;
        punti_ui.text = punteggioSquadra.ToString();
        puntiGameOver.text = "Punti: "+punteggioSquadra.ToString();
    }
}
