using UnityEngine;

public class ScoreColliderDuck : MonoBehaviour
{
    public int scorePerEnter = 10;
    private ScoreManagerDuck scoreManager;

    void Start()
    {
        scoreManager = GameObject.FindObjectOfType<ScoreManagerDuck>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            scoreManager.IncreaseScore(scorePerEnter);
            Debug.Log("Score increased! New score: " + scoreManager.score);
        }
    }
}
