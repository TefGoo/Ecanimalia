using UnityEngine;
using System.Collections;
using TMPro;

public class LevelLoader : MonoBehaviour
{
    public GameObject timerPanel;
    public TMP_Text timerText;
    public float delaySeconds = 3f;

    private void Awake()
    {
        // Show the timer panel
        timerPanel.SetActive(true);

        // Stop time in the scene
        Time.timeScale = 0f;

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
