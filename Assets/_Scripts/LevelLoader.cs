using UnityEngine;
using System.Collections;
using TMPro;

public class LevelLoader : MonoBehaviour
{
    public GameObject timerPanel;
    public TMP_Text timerText;
    public float delaySeconds = 3f;
    public GameManager gameManager; // Reference to the GameManager
    public SceneData currentSceneData; // Store the scene-specific data


    private void Awake()
    {
        // Show the timer panel
        timerPanel.SetActive(true);

        // Stop time in the scene
        Time.timeScale = 0f;

        // Set the initial score in the GameManager
        gameManager.SetSceneData(currentSceneData); // Set the scene-specific data if needed
        gameManager.IncrementScore(); // Increment the score to set the initial value

        // Start the coroutine to countdown and enable the level
        StartCoroutine(CountdownAndEnableLevel());
    }


    private IEnumerator CountdownAndEnableLevel()
    {
        float timer = delaySeconds;

        // Update the timer text for the countdown
        while (timer > 0f)
        {
            timer -= Time.unscaledDeltaTime;
            timerText.text = Mathf.CeilToInt(timer).ToString();
            yield return null;
        }

        // Hide the timer panel
        timerPanel.SetActive(false);

        // Restore the time scale to normal
        Time.timeScale = 1f;
    }
}
