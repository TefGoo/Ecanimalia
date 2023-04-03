using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuCanvas;

    private void Start()
    {
        //Disable the pause menu canvas by default
        pauseMenuCanvas.SetActive(false);
    }

    private void Update()
    {
        // Check if the player presses the "escape" key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // If the pause menu canvas is already active, hide it and resume the game
            if (pauseMenuCanvas.activeSelf)
            {
                ResumeGame();
            }
            // If the pause menu canvas is not active, show it and pause the game
            else
            {
                PauseGame();
            }
        }
    }

    private void PauseGame()
    {
        // Enable the pause menu canvas
        pauseMenuCanvas.SetActive(true);

        // Pause the game
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        // Disable the pause menu canvas
        pauseMenuCanvas.SetActive(false);

        // Resume the game
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        // Reload the current scene to restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
