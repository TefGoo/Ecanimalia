using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public float speed = 2f;
    public float despawnPosition = -10f;

    private void Update()
    {
        // Move the pipe to the left
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Destroy the pipe if it goes off-screen
        if (transform.position.x < despawnPosition)
        {
            Destroy(gameObject);
        }
    }
}
