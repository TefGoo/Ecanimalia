using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public Sprite[] starSprites; // Array of star sprites

    private int score = 0;
    private int starRating = 0;
    private int highScore = 0;

    private const string HighScoreKey = "HighScore";

    public Image starImage; // Reference to the UI image to display the star

    private void Start()
    {
        highScore = PlayerPrefs.GetInt(HighScoreKey, 0);
        UpdateScoreText();
        UpdateStarRating();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    private void UpdateStarRating()
    {
        if (starRating < starSprites.Length)
        {
            starImage.sprite = starSprites[starRating];
        }
        else
        {
            starImage.sprite = null;
        }
    }

    public void IncrementScore()
    {
        score++;
        UpdateScoreText();

        if (score <= 5)
        {
            starRating = 0;
        }
        else if (score >= 6 && score <= 12)
        {
            starRating = 1;
        }
        else if (score >= 13 && score <= 20)
        {
            starRating = 2;
        }
        else if (score > 21)
        {
            starRating = 3;
        }

        UpdateStarRating();

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt(HighScoreKey, highScore);
        }
    }

    public void GameOver()
    {
        // Perform necessary game over actions
    }
}
