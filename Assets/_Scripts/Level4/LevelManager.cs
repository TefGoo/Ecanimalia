using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public RandomSpawner randomSpawner;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public GameObject gameOverObject;

    private int score = 0;

    private static LevelManager instance;

    public static LevelManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<LevelManager>();
            return instance;
        }
    }

    private void Start()
    {
        UpdateHealthText();
        UpdateScoreText();
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    public void DecreaseHealth(int amount)
    {
        playerHealth.TakeDamage(amount);
        UpdateHealthText();

        if (playerHealth.currentHealth <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Time.timeScale = 0f; // Pause the game by setting the time scale to 0
        gameOverObject.SetActive(true);
    }

    public void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    public void UpdateHealthText()
    {
        if (healthText != null && playerHealth != null)
        {
            healthText.text = "Health: " + playerHealth.currentHealth.ToString();
        }
    }
}
