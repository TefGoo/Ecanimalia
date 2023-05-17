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

    private SpriteRenderer spriteRenderer;
    private Sprite originalSprite;
    private bool canInteract = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalSprite = spriteRenderer.sprite;
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
            spriteRenderer.sprite = newSprite;
            displayText.gameObject.SetActive(true);
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            spriteRenderer.sprite = originalSprite;
            displayText.gameObject.SetActive(false);
            canInteract = false;
        }
    }
}
