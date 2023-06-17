using UnityEngine;
using TMPro;

public class WhaleHealth : MonoBehaviour
{
    public int maxHealth = 8;  // Maximum health of the player (whale)
    public GameObject gameOverObject;  // Game object to activate when player's health reaches 0
    public TextMeshProUGUI lifeText;  // TMP text component to display the current life

    private int currentHealth;  // Current health of the player

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateLifeText();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            HandlePlayerDeath();
        }

        UpdateLifeText();
    }

    private void UpdateLifeText()
    {
        lifeText.text = "Life: " + currentHealth.ToString();
    }

    private void HandlePlayerDeath()
    {
        // Activate the game over object
        gameOverObject.SetActive(true);
    }
}
