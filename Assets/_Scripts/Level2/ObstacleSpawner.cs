using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // array of obstacle prefabs to spawn
    public float minSpawnInterval = 1f; // minimum time between obstacle spawns
    public float maxSpawnInterval = 3f; // maximum time between obstacle spawns
    public float obstacleSpeed = 5f; // speed at which obstacles move

    private float spawnTimer; // timer for obstacle spawns
    private float nextSpawnTime; // time of next obstacle spawn

    void Start()
    {
        // set initial next spawn time
        nextSpawnTime = Time.time + GetRandomSpawnInterval();
    }

    void Update()
    {
        // check if it's time to spawn a new obstacle
        if (Time.time >= nextSpawnTime)
        {
            // get random obstacle prefab
            int index = Random.Range(0, obstaclePrefabs.Length);
            GameObject obstaclePrefab = obstaclePrefabs[index];

            // instantiate obstacle at spawn point
            Vector3 spawnPos = transform.position;
            GameObject obstacle = Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);

            // set obstacle speed
            ObstacleMovement obstacleMovement = obstacle.GetComponent<ObstacleMovement>();
            if (obstacleMovement != null)
            {
                obstacleMovement.speed = obstacleSpeed;
            }

            // set next spawn time
            nextSpawnTime = Time.time + GetRandomSpawnInterval();
        }
    }

    float GetRandomSpawnInterval()
    {
        // return a random spawn interval between the minimum and maximum values
        return Random.Range(minSpawnInterval, maxSpawnInterval);
    }
}
