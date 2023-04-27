using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 5f; // speed at which obstacle moves

    void Update()
    {
        // move obstacle to the left
        transform.position += Vector3.left * speed * Time.deltaTime;

        // destroy obstacle when it goes off-screen to the left
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}
