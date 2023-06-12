using UnityEngine;

public class MoleController : MonoBehaviour
{
    public WhackAMoleGame whackAMoleGame;
    public SpriteRenderer spriteRenderer;
    public Sprite damagedSprite;
    public float moveSpeed = 1f;
    public float moveDistance = 1f;

    private bool isShowing = false;
    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.position;
    }

    private void Update()
    {
        if (isShowing)
        {
            float newY = originalPosition.y + (Mathf.Sin(Time.time * moveSpeed) * moveDistance);
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }
    }

    private void OnMouseDown()
    {
        if (isShowing)
        {
            DefeatMole();
        }
    }

    private void ShowMole()
    {
        isShowing = true;
        spriteRenderer.enabled = true;
    }

    private void HideMole()
    {
        isShowing = false;
        spriteRenderer.enabled = false;
    }

    private void DefeatMole()
    {
        if (whackAMoleGame != null)
        {
            whackAMoleGame.MoleDefeated(gameObject);
        }

        if (damagedSprite != null)
        {
            spriteRenderer.sprite = damagedSprite;
        }

        Destroy(gameObject, 0.2f);
    }

    public void Spawn()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Assign the sprite renderer
        ShowMole();
    }
}
