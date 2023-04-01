using UnityEngine;

public class FlappyBirdMovement : MonoBehaviour
{
    public float jumpForce = 5f;    // The force with which the player jumps
    public float forwardSpeed = 2f; // The speed at which the player moves forward
    public float maxUpwardVelocity = 5f; // The maximum upward velocity the player can have
    public float maxDownwardVelocity = -5f; // The maximum downward velocity the player can have

    private Rigidbody2D rb2d; // The rigidbody component of the player

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the space bar or left mouse button is pressed
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            // Make the player jump
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        }
    }

    // FixedUpdate is called at a fixed interval (50 times per second by default)
    void FixedUpdate()
    {
        // Move the player forward
        rb2d.velocity = new Vector2(forwardSpeed, rb2d.velocity.y);

        // Limit the player's upward and downward velocity
        if (rb2d.velocity.y > maxUpwardVelocity)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, maxUpwardVelocity);
        }
        else if (rb2d.velocity.y < maxDownwardVelocity)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, maxDownwardVelocity);
        }
    }
}
