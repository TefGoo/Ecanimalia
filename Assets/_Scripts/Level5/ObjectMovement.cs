using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float movementSpeed = 5f;  // Speed of the object

    private Vector3 targetPosition;

    private void Start()
    {
        // Set the target position as the center of the screen
        targetPosition = Vector3.zero;
    }

    private void Update()
    {
        // Move the object towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);

        // Check if the object has reached the target position
        if (transform.position == targetPosition)
        {
            // Reset the target position to a new random position
            targetPosition = GetRandomTargetPosition();
        }
    }

    private Vector3 GetRandomTargetPosition()
    {
        // Calculate a new random target position
        return new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), 0f);
    }
}
