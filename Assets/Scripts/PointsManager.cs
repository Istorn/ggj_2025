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

    private List<int> scores = new List<int>();

    void Start()
    {
        met_ResetPunti();
        scores = LoadScores("scores.txt");

        // Ensure there are exactly 3 scores
        while (scores.Count < 3)
        {
            scores.Add(0); // Fill missing slots with 0
        }
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
        puntiGameOver.text = "Punti: " + punteggioSquadra.ToString();
    }

    public int getCurrentScore()
    {
        return punteggioSquadra;
    }

    public List<int> LoadScores(string filePath)
    {
        Debug.Log("Reading file scores");
        List<int> scores = new List<int>();

        if (!File.Exists(filePath))
        {
            Debug.Log("File does not exist");
            Debug.Log(filePath);
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
        }

        // Ensure there are exactly 3 scores
        scores.Sort((a, b) => b.CompareTo(a));
        while (scores.Count < 3)
        {
            scores.Add(0); // Fill with zeros if less than 3
        }

        return scores.Take(3).ToList(); // Only take the top 3 scores
    }

    public void AddScore(List<int> scores, int newScore)
    {
        // Check if the new score is greater than the lowest score
        if (newScore > scores[scores.Count - 1])
        {
            scores[scores.Count - 1] = newScore; // Replace the lowest score
            scores.Sort((a, b) => b.CompareTo(a)); // Sort in descending order
        }
    }

    public void SaveScores(string filePath, List<int> scores)
    {
        File.WriteAllLines(filePath, scores.Select(score => score.ToString()));
    }

    public void met_GameOver()
    {
        Debug.LogError("Points manager game over");

        // Add the current score and ensure only the top 3 scores are kept
        AddScore(scores,getCurrentScore());
        SaveScores("scores.txt", scores);

        // Update top scores UI
        topScore1.text = scores.Count > 0 ? scores[0].ToString() : "0";
        topScore2.text = scores.Count > 1 ? scores[1].ToString() : "0";
        topScore3.text = scores.Count > 2 ? scores[2].ToString() : "";

        Debug.Log("Game over. Top scores updated.");
    }
}
