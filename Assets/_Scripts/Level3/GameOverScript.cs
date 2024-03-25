using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour
{
    public Canvas gameOverCanvas; // Reference to the game over canvas
    public float delayTime = 1f; // Delay time before showing game over canvas

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ShowGameOverCanvas());
        }
    }

    private IEnumerator ShowGameOverCanvas()
    {
        // Wait for the delay time
        yield return new WaitForSeconds(delayTime);

        // Enable the game over canvas
        gameOverCanvas.gameObject.SetActive(true);

        // Pause the game
        Time.timeScale = 0;
    }
}
