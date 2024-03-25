using UnityEngine;
using TMPro;

public class WhaleHealth : MonoBehaviour
{
    public int maxHealth = 8;
    public GameObject gameOverObject;
    public TextMeshProUGUI lifeText;

    public float cameraShakeDuration = 0.2f;
    public float cameraShakeIntensity = 0.1f;

    private int currentHealth;

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
        else
        {
            // Trigger camera shake effect
            CameraShaker.ShakeCamera(cameraShakeDuration, cameraShakeIntensity);

        }

        UpdateLifeText();
    }

    private void UpdateLifeText()
    {
        lifeText.text = currentHealth.ToString();
    }

    private void HandlePlayerDeath()
    {
        WhaleController whaleController = GetComponent<WhaleController>();
        if (whaleController != null)
        {
            whaleController.enabled = false;
        }

        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager != null)
        {
            scoreManager.StopScoring();
        }
        Destroy(gameObject);

        gameOverObject.SetActive(true);
    }
}
