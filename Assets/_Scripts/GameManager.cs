using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.Localization;

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public Image starImage;

    private int score = 0;
    private int starRating = 0;
    private int highScore = 0;

    private const string HighScoreKey = "HighScore";
    public SceneData currentSceneData; // Store the scene-specific data
    public LocalizedString scoreTextPrefix; // Localized string for the score text prefix

    private void Start()
    {
        // Get the name of the currently active scene
        string currentSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        // Use the current scene's name to load the appropriate SceneData asset
        currentSceneData = Resources.Load<SceneData>("SceneData/SceneData_" + currentSceneName);

        if (currentSceneData == null)
        {
            Debug.LogError("Scene Data Not Found for scene: " + currentSceneName);
        }
        else
        {
            highScore = PlayerPrefs.GetInt(HighScoreKey, 0);
            score = currentSceneData.initialScore; // Initialize score with scene-specific initial score
            UpdateScoreText();
            UpdateStarRating();
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = scoreTextPrefix.GetLocalizedString() + score.ToString();
    }

    private void UpdateStarRating()
    {
        int newStarRating = -1; // Default to -1 if no range matches

        // Check each score range defined in the SceneData
        foreach (var range in currentSceneData.scoreRanges)
        {
            if (score >= range.minScore && score <= range.maxScore)
            {
                newStarRating = currentSceneData.scoreRanges.ToList().IndexOf(range);
                break; // Exit the loop as soon as we find a matching range
            }
        }

        if (newStarRating != -1)
        {
            starRating = newStarRating;
            starImage.sprite = currentSceneData.scoreRanges[starRating].sprite;
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

    // You may also want to add a method to update the scene-specific data
    public void SetSceneData(SceneData sceneData)
    {
        currentSceneData = sceneData;
        score = sceneData.initialScore;
        UpdateScoreText();
        UpdateStarRating();
    }

    public void RegisterScore(int newScore)
    {
        score = newScore;
        UpdateScoreText();
        UpdateStarRating();

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt(HighScoreKey, highScore);
        }
    }

}
