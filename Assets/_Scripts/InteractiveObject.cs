using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class InteractiveObject : MonoBehaviour
{
    public Sprite newSprite;
    public TMP_Text displayText;
    public KeyCode interactKey = KeyCode.E;
    public Collider2D triggerCollider;
    public string levelToLoad;

    public Vector3 newScale = Vector3.one; // Set your desired scale here

    private SpriteRenderer childSpriteRenderer;
    private Sprite originalSprite;
    private Vector3 originalScale;
    private bool canInteract = false;

    private void Start()
    {
        // Find the child object with a SpriteRenderer component
        childSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        originalSprite = childSpriteRenderer.sprite;
        originalScale = childSpriteRenderer.transform.localScale;
        displayText.gameObject.SetActive(false);
        triggerCollider.enabled = false;
    }

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(interactKey))
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Change the sprite and scale of the child object
            childSpriteRenderer.sprite = newSprite;
            childSpriteRenderer.transform.localScale = newScale;
            displayText.gameObject.SetActive(true);
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Restore the original sprite and scale of the child object
            childSpriteRenderer.sprite = originalSprite;
            childSpriteRenderer.transform.localScale = originalScale;
            displayText.gameObject.SetActive(false);
            canInteract = false;
        }
    }
}
