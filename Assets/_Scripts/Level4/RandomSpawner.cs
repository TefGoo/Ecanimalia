using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;  // Array of spawn points for the sprite
    public float minSpawnDelay = 2f; // Minimum delay between spawns
    public float maxSpawnDelay = 5f; // Maximum delay between spawns
    public float moveDelay = 1f;     // Delay before moving the sprite
    public float moveDistance = 1f;  // Distance to move the sprite
    public float spawnerCooldown = 10f; // Cooldown between spawner activations

    public Sprite spriteToSpawn; // Sprite to spawn

    public bool spawnerReady = true; // Flag to indicate if the spawner is ready to spawn

    private void Start()
    {
        Invoke("SpawnSprite", spawnerCooldown);
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

        GameObject spriteObject = ObjectPooler.Instance.SpawnFromPool("Sprite", currentSpawnPoint.position, Quaternion.identity);

        SpriteRenderer spriteRenderer = spriteObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteToSpawn;

        BoxCollider2D collider = spriteObject.GetComponent<BoxCollider2D>();
        collider.isTrigger = true;

        SpriteClickHandler clickHandler = spriteObject.GetComponent<SpriteClickHandler>();
        clickHandler.randomSpawner = this;

        StartCoroutine(MoveSprite(spriteObject.transform));

        // The mole should stay up for a complete second
        Invoke("HideSprite", 1f);
        Invoke("HandleMoleDespawn", 1f);

        // Reset the spawner to ready after spawning
        spawnerReady = false;
        Invoke("ResetSpawnerReady", Random.Range(minSpawnDelay, maxSpawnDelay));
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
            yield return new WaitForSeconds(moveDelay);

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

        // Coroutine is done, so return.
        yield break;
    }

    private void HideSprite()
    {
        // Hide the sprite after a complete second
        GameObject spriteObject = ObjectPooler.Instance.SpawnFromPool("Sprite");
        if (spriteObject != null)
        {
            DestroySprite(spriteObject, false); // Pass 'false' to indicate destruction by time
        }
    }

    private void HandleMoleDespawn()
    {
        LevelManager.Instance.DecreaseHealth(1);
    }

    public void DestroySprite(GameObject spriteObject, bool destroyedByClick)
    {
        if (destroyedByClick)
        {
            // If destroyed by click, do nothing, as the player clicked on the sprite
            return;
        }

        // If destroyed by time, increase score and return the sprite to the object pool
        LevelManager.Instance.IncreaseScore(1);
        ObjectPooler.Instance.ReturnToPool("Sprite", spriteObject);
    }

    private void ResetSpawnerReady()
    {
        spawnerReady = true; // Reset the spawner to ready
        SpawnSprite(); // Trigger the next spawn immediately after resetting
    }
}
