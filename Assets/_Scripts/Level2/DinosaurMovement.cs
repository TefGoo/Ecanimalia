using System.Collections;
using UnityEngine;

public class DinosaurMovement : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10f; // The force applied when the player jumps
    [SerializeField] private float crouchScale = 0.5f; // The scale applied to the player when crouching
    [SerializeField] private float crouchSpeed = 5f; // The speed at which the player crouches and stands up
    [SerializeField] private LayerMask groundLayers; // The layers considered as ground for the player

    public Sprite crouchSprite; // The sprite to use when crouching
    public Sprite jumpSprite; // The sprite to use when jumping

    private bool isJumping = false; // Whether the player is currently jumping
    private bool isCrouching = false; // Whether the player is currently crouching
    private float originalScale; // The player's original scale
    private Rigidbody2D rb; // The player's rigidbody component
    private SpriteRenderer spriteRenderer; // The player's sprite renderer component
    private Sprite defaultSprite; // The player's default sprite

    void Start()
    {
        originalScale = transform.localScale.y;
        rb = GetComponent<Rigidbody2D>();

        // Find the SpriteRenderer on the child object
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        defaultSprite = spriteRenderer.sprite;
    }

    void Update()
    {
        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping && !isCrouching)
        {
            isJumping = true;
            rb.velocity = Vector2.up * jumpForce;
            spriteRenderer.sprite = jumpSprite;
        }

        // Crouching
        if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.X)) && !isJumping && !isCrouching)
        {
            isCrouching = true;
            StartCoroutine(CrouchRoutine());
        }
        else if ((Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.X)) && isCrouching)
        {
            isCrouching = false;
            StartCoroutine(StandUpRoutine());
        }

        // Change sprite while crouching
        if (isCrouching)
        {
            spriteRenderer.sprite = crouchSprite;
        }
        else if (!isJumping)
        {
            spriteRenderer.sprite = defaultSprite;
        }
    }

    IEnumerator CrouchRoutine()
    {
        while (transform.localScale.y > originalScale * crouchScale)
        {
            float newScale = Mathf.Max(transform.localScale.y - crouchSpeed * Time.deltaTime, originalScale * crouchScale);
            transform.localScale = new Vector3(transform.localScale.x, newScale, transform.localScale.z);
            yield return null;
        }
    }

    IEnumerator StandUpRoutine()
    {
        while (transform.localScale.y < originalScale)
        {
            float newScale = Mathf.Min(transform.localScale.y + crouchSpeed * Time.deltaTime, originalScale);
            transform.localScale = new Vector3(transform.localScale.x, newScale, transform.localScale.z);
            yield return null;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Reset jump when the player lands on the ground
        if (((1 << collision.gameObject.layer) & groundLayers.value) != 0)
        {
            isJumping = false;
            spriteRenderer.sprite = defaultSprite;
        }
    }
}
