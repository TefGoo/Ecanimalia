using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectPrefab;  // Prefab of the object to be spawned
    public float spawnInterval = 2f;  // Interval between object spawns
    public float spawnDistance = 10f;  // Distance from the screen edge where objects will spawn

    private float spawnTimer;

    private void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f)
        {
            SpawnObject();
            spawnTimer = spawnInterval;
        }
    }

    private void SpawnObject()
    {
        // Calculate a random position outside the screen
        Vector3 spawnPosition = GetRandomSpawnPosition();

        // Instantiate the object at the spawn position
        Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
    }

    private Vector3 GetRandomSpawnPosition()
    {
        Vector3 spawnPosition = Vector3.zero;

        // Determine a random spawn position on one of the screen edges
        int edgeIndex = Random.Range(0, 4);
        float xSpawnOffset = Random.Range(-1f, 1f);  // Offset the spawn position along the x-axis
        float ySpawnOffset = Random.Range(-1f, 1f);  // Offset the spawn position along the y-axis

        switch (edgeIndex)
        {
            case 0: // Top edge
                spawnPosition = new Vector3(xSpawnOffset * (GetScreenRightBound() - GetScreenLeftBound()) + GetScreenLeftBound(), GetScreenTopBound() + spawnDistance);
                break;
            case 1: // Bottom edge
                spawnPosition = new Vector3(xSpawnOffset * (GetScreenRightBound() - GetScreenLeftBound()) + GetScreenLeftBound(), GetScreenBottomBound() - spawnDistance);
                break;
            case 2: // Left edge
                spawnPosition = new Vector3(GetScreenLeftBound() - spawnDistance, ySpawnOffset * (GetScreenTopBound() - GetScreenBottomBound()) + GetScreenBottomBound());
                break;
            case 3: // Right edge
                spawnPosition = new Vector3(GetScreenRightBound() + spawnDistance, ySpawnOffset * (GetScreenTopBound() - GetScreenBottomBound()) + GetScreenBottomBound());
                break;
        }

        return spawnPosition;
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
