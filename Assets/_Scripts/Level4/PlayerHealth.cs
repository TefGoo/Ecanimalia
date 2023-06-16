using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;             // Maximum health of the player
    public TextMeshProUGUI healthText;    // TMP text to display the player's health
    public GameObject gameOverObject;     // Game object to activate when the player's health reaches zero

    private int currentHealth;            // Current health of the player

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthText();
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        UpdateHealthText();

        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    private void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth.ToString();
        }
    }

    private void GameOver()
    {
        Time.timeScale = 0f; // Pause the game by setting the time scale to 0
        gameOverObject.SetActive(true);
    }
}
