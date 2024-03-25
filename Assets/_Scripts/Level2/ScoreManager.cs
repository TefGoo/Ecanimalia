using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score;

    private bool isScoringEnabled = true;
    private GameManager gameManager; // Reference to the GameManager script

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); // Find the GameManager script in the scene
        score = 0;
        InvokeRepeating("IncrementScore", 0.3f, 0.3f);
    }

    private void IncrementScore()
    {
        if (isScoringEnabled && !CharacterControllerDino.isGameOver)
        {
            score++;
            scoreText.text =score+" ECAs".ToString();
            gameManager.IncrementScore(); // Call the IncrementScore() method in the GameManager script
        }
    }

    public void StopScoring()
    {
        isScoringEnabled = false;
    }
}
