using UnityEngine;

public class ContinuousMovement : MonoBehaviour
{
    public float speed = 5f; // Adjust the speed as per your requirement

    private void Update()
    {
        // Move the object to the left
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Check if the object has moved off the screen
        if (transform.position.x < -10f) // Adjust the value based on your object's width
        {
            // Reset the object's position to the right of the screen
            float newX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x + 10f; // Adjust the value based on your object's width
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        }
    }
}
