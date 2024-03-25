using UnityEngine;
using TMPro;

public class ScoreManagerDuck : MonoBehaviour
{
    public TMP_Text scoreText;
    public int score = 0;

    private GameManager gameManager; // Reference to the GameManager script

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); // Find the GameManager script in the scene
        UpdateScoreUI();
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreUI();

        gameManager.IncrementScore(); // Call the IncrementScore() method in the GameManager script
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text =  score.ToString();
        }
    }
}
