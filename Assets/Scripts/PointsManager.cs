using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    public int punteggioSquadra;
    public Text punti_ui;
    public Text puntiGameOver;

    public Text topScore1, topScore2, topScore3;

    List<int> scores;
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
                File.Create(filePath).Close();
            }
        else
        {
            foreach (string line in File.ReadAllLines(filePath))
            {
                if (int.TryParse(line, out int score))
                {
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

        scores = LoadScores(Resources.Load<TextAsset>("scores").ToString());
        if (scores.Count() >0){
            topScore1.text = scores[0].ToString();
            topScore2.text = scores.Count>1? scores[1].ToString(): "";
            topScore3.text = scores.Count>2? scores[2].ToString(): "";
        }else{
            AddScore(scores,getCurrentScore());
            SaveScores(Resources.Load<TextAsset>("scores").ToString(),scores);
            scores = LoadScores(Resources.Load<TextAsset>("scores").ToString());
            topScore1.text = scores[0].ToString();
            topScore2.text = scores.Count>1? scores[1].ToString(): "";
            topScore3.text = scores.Count>2? scores[2].ToString(): "";


        }
        
    }
}
