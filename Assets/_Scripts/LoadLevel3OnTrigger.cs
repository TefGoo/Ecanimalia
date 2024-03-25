using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel3OnTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene("Level3");
        }
    }
}
