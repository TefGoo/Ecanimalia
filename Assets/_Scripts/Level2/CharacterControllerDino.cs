using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterControllerDino : MonoBehaviour
{
    public static bool isGameOver = false;
    public Canvas gameOverCanvas;
    public float delayTime = 2f;

    private bool isDead = false;

    private ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") && !isDead)
        {
            isDead = true;
            StartCoroutine(GameOverWithDelay());
        }
    }
    public GameObject objectToDestroy;


    private IEnumerator GameOverWithDelay()
    {
        // Disable character controls
        GetComponent<DinosaurMovement>().enabled = false;

        // Disable collider
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.enabled = false;
        }

        // Set the isGameOver flag in the GameManager script
        isGameOver = true;

        // Wait for the delay time
        yield return new WaitForSeconds(delayTime);

        // Enable the game over canvas
        gameOverCanvas.gameObject.SetActive(true);

        // Pause the game
        Time.timeScale = 0;

        // Destroy the specified game object
        if (objectToDestroy != null)
        {
            Destroy(objectToDestroy);
        }
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}