using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private float speed;

    public void Initialize(float obstacleSpeed)
    {
        speed = obstacleSpeed;
    }

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // Remove obstacle if it goes off the screen
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}
