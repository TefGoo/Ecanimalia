using UnityEngine;

public class WhaleController : MonoBehaviour
{
    public float movementSpeed = 5f;  // Adjust this value to control the speed of the whale
    public float rotationSpeed = 3f;  // Adjust this value to control the rotation speed of the whale

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;  // Disable gravity for the whale
    }

    private void Update()
    {
        // Get the position of the mouse cursor in world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;  // Ensure that the z-coordinate is 0 for 2D movement

        // Rotate the whale to face the mouse cursor
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, mousePosition - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

        // Move the whale towards the mouse cursor
        rb.velocity = (mousePosition - transform.position).normalized * movementSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Calculate the reflection direction based on the collision normal
        Vector2 reflectionDirection = Vector2.Reflect(rb.velocity, collision.contacts[0].normal).normalized;

        // Update the whale's velocity with the reflection direction
        rb.velocity = reflectionDirection * movementSpeed;
    }

    private void LateUpdate()
    {
        // Clamp the whale's position to the screen borders
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, GetScreenLeftBound(), GetScreenRightBound());
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, GetScreenBottomBound(), GetScreenTopBound());
        transform.position = clampedPosition;
    }

    private float GetScreenLeftBound()
    {
        return Camera.main.ScreenToWorldPoint(Vector3.zero).x;
    }

    private float GetScreenRightBound()
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0f)).x;
    }

    private float GetScreenBottomBound()
    {
        return Camera.main.ScreenToWorldPoint(Vector3.zero).y;
    }

    private float GetScreenTopBound()
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(0f, Screen.height)).y;
    }
}
