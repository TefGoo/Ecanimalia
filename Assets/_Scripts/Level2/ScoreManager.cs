using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score;

    private bool isScoringEnabled = true;

    private void Start()
    {
        score = 0;
        InvokeRepeating("IncrementScore", 0.3f, 0.3f);
    }

    private void IncrementScore()
    {
        if (isScoringEnabled && !CharacterControllerDino.isGameOver)
        {
            score++;
            scoreText.text = "Score: " + score.ToString();
        }
    }

    public void StopScoring()
    {
        isScoringEnabled = false;
    }
}
