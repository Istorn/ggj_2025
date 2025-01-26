using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    public int punteggioSquadra;
    public Text punti_ui;
    public Text puntiGameOver;

    public Text topScore1, topScore2, topScore3;

    List<int> scores = new List<int>();
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

    public int getCurrentScore(){
        return punteggioSquadra;
    }


    public List<int> LoadScores(string filePath) {
        Debug.Log("read file scores");
        List<int> scores = new List<int>();

        if (!File.Exists(filePath))
            {
                Debug.Log("File does not exists");
                Debug.Log(filePath);
                File.Create(filePath).Close();
            }
        else
        {
            foreach (string line in File.ReadAllLines(filePath))
            {
                if (int.TryParse(line, out int score))
                {
                    Debug.Log(score);
                    scores.Add(score);
                }
            }

            // Sort the scores in descending order
            scores.Sort((a, b) => b.CompareTo(a));
        }

        return scores;
    } 

    public void AddScore(List<int> scores, int scoreToAdd){
        scores.Add(scoreToAdd);

        // Keep the order

        scores.Sort((score1,score2) => score2.CompareTo(score1));
    }

    public void SaveScores(string filePath, List<int> scores){
        File.WriteAllLines(filePath,scores.Select(score => score.ToString()));
    }
    
    public void met_GameOver()
    {
        Debug.LogError("Points manager game over");

        
        AddScore(scores,getCurrentScore());
        SaveScores("scores.txt",scores);
        scores = LoadScores("scores.txt");

        Debug.Log("adwfadsfasdasd");
        Debug.Log(scores[scores.Count - 1]);
            
        
        topScore1.text = scores[scores[scores.Count - 1]].ToString();
        topScore2.text = scores.Count>1? scores[scores.Count - 2].ToString(): "";
        topScore3.text = scores.Count>2? scores[scores.Count - 3].ToString(): "";
        
    }
}
