using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score;

    private void Start()
    {
        score = 0;
        InvokeRepeating("IncrementScore", 0.3f, 0.3f);
    }

    private void IncrementScore()
    {
        if (!CharacterControllerDino.isGameOver)
        {
            score++;
            scoreText.text = "Score: " + score.ToString();
        }
    }
}