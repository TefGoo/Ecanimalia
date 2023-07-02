using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpacityDecrease : MonoBehaviour
{
    public float duration = 1f; // Duration of the opacity decrease effect
    private float elapsedTime = 0f; // Elapsed time since the effect started
    private bool isTransitionComplete = false; // Flag indicating if the opacity decrease effect has completed

    private Image panelImage; // Reference to the Image component of the panel

    private void Start()
    {
        // Get the Image component attached to the panel
        panelImage = GetComponent<Image>();

        // Set the initial alpha value to 1 (fully visible)
        Color panelColor = panelImage.color;
        panelColor.a = 1f;
        panelImage.color = panelColor;
    }

    private void Update()
    {
        if (!isTransitionComplete)
        {
            // Update the elapsed time
            elapsedTime += Time.deltaTime;

            // Calculate the current alpha value based on the elapsed time and duration
            float currentAlpha = Mathf.Lerp(1f, 0f, elapsedTime / duration);

            // Update the alpha value of the panel's color
            Color panelColor = panelImage.color;
            panelColor.a = currentAlpha;
            panelImage.color = panelColor;

            // Check if the duration has elapsed
            if (elapsedTime >= duration)
            {
                isTransitionComplete = true;
            }
        }
    }

    public void ChangeScene()
    {
        // Load the next scene if the opacity decrease effect has completed
        if (isTransitionComplete)
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
}
