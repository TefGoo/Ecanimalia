using UnityEngine;

public class SceneSpeedManager : MonoBehaviour
{
    public float accelerationRate = 0.1f; // The rate at which the speed increases per second
    public float maxSpeed = 10.0f; // The maximum speed the scene can reach

    private float currentSpeed = 0.0f;
    private bool isPaused = false;

    private GameObject gameOverCanvas; // Reference to the game over canvas

    private void Start()
    {
        currentSpeed = Time.timeScale;

        // Find the game over canvas in the scene
        gameOverCanvas = GameObject.FindGameObjectWithTag("GameOverCanvas");
    }

    private void Update()
    {
        // Check if the game is paused or game over canvas is active
        isPaused = (Time.timeScale == 0) || (gameOverCanvas != null && gameOverCanvas.activeSelf);

        // If the game is not paused or game over canvas is not active, adjust speed
        if (!isPaused)
        {
            // Increase the speed based on the acceleration rate
            currentSpeed += accelerationRate * Time.deltaTime;

            // Clamp the speed to the maximum speed
            currentSpeed = Mathf.Clamp(currentSpeed, Time.timeScale, maxSpeed);

            // Apply the new speed to the time scale
            Time.timeScale = currentSpeed;
        }
    }
}
