using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrossyMovement : MonoBehaviour
{
    public Canvas gameOverCanvas;
    public float delayTime = 2f;

    private bool isDead = false;

    public float moveDistance = 3f;
    public float xMinLimit = -18f;
    public float xMaxLimit = 18f;
    public float yMinLimit = -18f;
    public float yMaxLimit = 162f;

    private void Update()
    {
        float x = transform.position.x;
        float y = transform.position.y;

        if (Input.GetKeyDown(KeyCode.W) || (Input.GetKeyDown(KeyCode.UpArrow) && y < yMaxLimit))
        {
            y += moveDistance;
        }
        else if (Input.GetKeyDown(KeyCode.A) || (Input.GetKeyDown(KeyCode.LeftArrow) && x > xMinLimit))
        {
            x -= moveDistance;
        }
        else if (Input.GetKeyDown(KeyCode.D) || (Input.GetKeyDown(KeyCode.RightArrow) && x < xMaxLimit))
        {
            x += moveDistance;
        }

        transform.position = new Vector2(x, y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Car") && !isDead)
        {
            isDead = true;
            StartCoroutine(GameOverWithDelay());
        }
    }

    private IEnumerator GameOverWithDelay()
    {
        // Disable character controls
        GetComponent<CrossyMovement>().enabled = false;

        // Disable collider
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.enabled = false;
        }

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