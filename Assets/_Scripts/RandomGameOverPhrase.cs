using UnityEngine;
using TMPro;

public class RandomGameOverPhrase : MonoBehaviour
{
    public TMP_Text gameOverText;
    public string[] gameOverPhrases;

    private void Start()
    {
        // Ensure there are phrases to choose from
        if (gameOverPhrases.Length > 0)
        {
            // Select a random phrase from the array
            string randomPhrase = gameOverPhrases[Random.Range(0, gameOverPhrases.Length)];

            // Display the random phrase in the game over text
            gameOverText.text = randomPhrase;
        }
        else
        {
            Debug.LogWarning("No game over phrases available.");
        }
    }
}
