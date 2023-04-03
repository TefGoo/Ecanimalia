using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    public Canvas gameOverCanvas;
    public float delayTime = 2f;

    private bool isDead = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") && !isDead)
        {
            isDead = true;
            StartCoroutine(GameOverWithDelay());
        }
    }

    private IEnumerator GameOverWithDelay()
    {
        // Disable character controls
        GetComponent<FlappyBirdMovement>().enabled = false;

        //Disable collider


        // Wait for the delay time
        yield return new WaitForSeconds(delayTime);

        // Enable the game over canvas
        gameOverCanvas.gameObject.SetActive(true);

        // Pause the game
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}