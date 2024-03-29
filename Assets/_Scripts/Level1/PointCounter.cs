using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointCounter : MonoBehaviour
{
    public TMP_Text scoreText; // The UI text to display the score
    public int score = 0; // The player's current score

    private bool scoredThisObstacle = false; // Whether the player has already scored for the current obstacle

    private GameManager gameManager; // Reference to the GameManager script

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); // Find the GameManager script in the scene
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle") && !scoredThisObstacle) // Check if the player collided with an obstacle and hasn't already scored for it
        {
            score++; // Add one to the player's score
            scoreText.text = score+ " ECAs".ToString(); // Update the score text in the UI
            scoredThisObstacle = true; // Set the scoredThisObstacle flag to true

            gameManager.IncrementScore(); // Call the IncrementScore() method in the GameManager script
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle")) // Check if the player has exited the obstacle
        {
            scoredThisObstacle = false; // Reset the scoredThisObstacle flag
        }
    }
}