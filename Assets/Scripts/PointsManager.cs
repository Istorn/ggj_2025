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
    private string filePath;

    void Start()
    {
        // Use Application.persistentDataPath for the file path
        filePath = Path.Combine(Application.persistentDataPath, "scores.txt");

        // Ensure the directory exists
        string directoryPath = Path.GetDirectoryName(filePath);
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
            Debug.Log("Created directory: " + directoryPath);
        }

        Debug.Log("Score file path: " + filePath);

        met_ResetPunti();
        scores = LoadScores(filePath);

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

        // Check if the file exists
        if (!File.Exists(filePath))
        {
            Debug.LogWarning("File does not exist. Creating a new one.");
            File.WriteAllText(filePath, "0\n0\n0"); // Create a file with default scores
        }

        // Read and parse scores
        foreach (string line in File.ReadAllLines(filePath))
        {
            if (int.TryParse(line, out int score))
            {
                scores.Add(score);
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
        // Only replace the lowest score if the new score is greater and not already in the list
        if (!scores.Contains(newScore) && newScore > scores[scores.Count - 1])
        {
            scores[scores.Count - 1] = newScore; // Replace the lowest score
            scores.Sort((a, b) => b.CompareTo(a)); // Sort in descending order
        }
    }

    public void SaveScores(string filePath, List<int> scores)
    {
        // Write scores back to the file
        File.WriteAllLines(filePath, scores.Select(score => score.ToString()));
        Debug.Log("Scores saved successfully at: " + filePath);
    }

    public void met_GameOver()
    {
        Debug.LogError("Points manager game over");

        // Add the current score and ensure only the top 3 scores are kept
        AddScore(scores, getCurrentScore());
        SaveScores(filePath, scores);

        // Update top scores UI
        topScore1.text = scores.Count > 0 ? scores[0].ToString() : "0";
        topScore2.text = scores.Count > 1 ? scores[1].ToString() : "0";
        topScore3.text = scores.Count > 2 ? scores[2].ToString() : "0";

        Debug.Log("Game over. Top scores updated.");
    }
}
