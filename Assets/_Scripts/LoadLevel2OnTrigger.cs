using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel2OnTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene("Level2");
        }
    }
}
