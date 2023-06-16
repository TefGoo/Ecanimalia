using UnityEngine;
using TMPro;

public class RandomSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;  // Array of spawn points for the sprite
    public float minSpawnDelay = 2f; // Minimum delay between spawns
    public float maxSpawnDelay = 5f; // Maximum delay between spawns
    public float moveDelay = 1f;     // Delay before moving the sprite
    public float moveDistance = 1f;  // Distance to move the sprite
    public float spawnerCooldown = 10f; // Cooldown between spawner activations

    public TextMeshProUGUI scoreText; // TMP text to display the score

    public Sprite spriteToSpawn; // Sprite to spawn

    private int score = 0;
    private bool spawnerReady = true; // Flag to indicate if the spawner is ready to spawn

    private void Start()
    {
        Invoke("SpawnSprite", Random.Range(minSpawnDelay, maxSpawnDelay));
    }

    private void SpawnSprite()
    {
        if (!spawnerReady)
        {
            Invoke("SpawnSprite", spawnerCooldown);
            return;

        }

        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform currentSpawnPoint = spawnPoints[randomIndex];

        GameObject spriteObject = new GameObject("Sprite");
        spriteObject.transform.position = currentSpawnPoint.position;

        SpriteRenderer spriteRenderer = spriteObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteToSpawn;

        BoxCollider2D collider = spriteObject.AddComponent<BoxCollider2D>();
        collider.isTrigger = true;

        SpriteClickHandler clickHandler = spriteObject.AddComponent<SpriteClickHandler>();
        clickHandler.randomSpawner = this;

        StartCoroutine(MoveSprite(spriteObject.transform));

        Invoke("ResetSpritePosition", 4f);

        spawnerReady = false; // Set the spawner to not ready
        Invoke("ResetSpawnerReady", spawnerCooldown); // Reset the spawner to ready after the cooldown

        Invoke("SpawnSprite", Random.Range(minSpawnDelay, maxSpawnDelay));
        StartCoroutine(DestroySpriteAfterDelay(spriteObject));
    }

    private System.Collections.IEnumerator MoveSprite(Transform spriteTransform)
    {
        float targetY = spriteTransform.position.y + moveDistance;
        float startTime = Time.time;
        float journeyLength = targetY - spriteTransform.position.y;

        while (spriteTransform != null && spriteTransform.position.y < targetY)
        {
            if (spriteTransform == null)
                yield break; // Exit the coroutine if the spriteTransform is null

            float distCovered = (Time.time - startTime) * moveDistance;
            float fracJourney = distCovered / journeyLength;
            spriteTransform.position = new Vector3(spriteTransform.position.x, spriteTransform.position.y + fracJourney, spriteTransform.position.z);
            yield return null;
        }

        if (spriteTransform != null)
        {
            yield return new WaitForSeconds(4f);

            targetY = spriteTransform.position.y - moveDistance;
            startTime = Time.time;
            journeyLength = spriteTransform.position.y - targetY;

            while (spriteTransform != null && spriteTransform.position.y > targetY)
            {
                if (spriteTransform == null)
                    yield break; // Exit the coroutine if the spriteTransform is null

                float distCovered = (Time.time - startTime) * moveDistance;
                float fracJourney = distCovered / journeyLength;
                spriteTransform.position = new Vector3(spriteTransform.position.x, spriteTransform.position.y - fracJourney, spriteTransform.position.z);
                yield return null;
            }
        }
    }


    private System.Collections.IEnumerator DestroySpriteAfterDelay(GameObject spriteObject)
    {
        yield return new WaitForSeconds(5f);
        DestroySprite(spriteObject, false); // Pass 'false' to indicate destruction by time
        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(1);
        }
    }

    public void DestroySprite(GameObject spriteObject, bool destroyedByClick)
    {
        if (destroyedByClick)
        {
            score++;
            UpdateScoreText();
        }

        Destroy(spriteObject);
    }

    private void ResetSpritePosition()
    {
        // No need to reset the position in this modified version
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.tag == "Sprite")
            {
                DestroySprite(hit.collider.gameObject, true); // Pass 'true' to indicate destruction by click
            }
        }
    }

    private void ResetSpawnerReady()
    {
        spawnerReady = true; // Reset the spawner to ready
    }
}
