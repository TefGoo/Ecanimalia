using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    public Canvas transitionCanvas; // Reference to the transition canvas
    public Image transitionPanel; // Reference to the panel in the transition canvas
    public float transitionDuration = 1f; // Duration of the transition effect

    private void Start()
    {
        // Set the initial opacity of the transition panel to 0
        Color panelColor = transitionPanel.color;
        panelColor.a = 0f;
        transitionPanel.color = panelColor;
    }

    public void StartTransition()
    {
        // Set the transition canvas active
        transitionCanvas.gameObject.SetActive(true);

        // Start the fade-in transition effect
        StartCoroutine(FadeInTransitionPanel());
    }

    private IEnumerator FadeInTransitionPanel()
    {
        // Get the initial opacity of the transition panel
        Color panelColor = transitionPanel.color;
        float currentAlpha = panelColor.a;

        // Calculate the target opacity of the transition panel
        float targetAlpha = 1f;

        // Gradually increase the opacity of the transition panel over time
        float elapsedTime = 0f;
        while (elapsedTime < transitionDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / transitionDuration);
            panelColor.a = Mathf.Lerp(currentAlpha, targetAlpha, t);
            transitionPanel.color = panelColor;
            yield return null;
        }

        // Load the next scene after the transition effect completes
        LoadNextScene();
    }

    private void LoadNextScene()
    {
        // Get the current scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Calculate the index of the next scene
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
            nextSceneIndex = 0; // Wrap around to the first scene if it's the last scene

        // Load the next scene
        SceneManager.LoadScene(nextSceneIndex);
    }
}
