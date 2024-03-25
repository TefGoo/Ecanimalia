using UnityEngine;

public class EnvironmentSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public GameObject pipePrefab2;
    public float spawnDelay = 2f;
    public float spawnRange = 3f;
    public float speed = 2f;
    public float maxSpeed = 10f;
    public float speedIncreasePerSecond = 0.2f;
    public float spawnPosition = 10f;
    public float despawnPosition = -10f;
    public float pipeGap = 2f;
    public float pipeMinHeight = -2f;
    public float pipeMaxHeight = 2f;

    private float lastSpawnTime;
    private float currentSpeed;

    private void Update()
    {
        // Increase the current speed based on the time elapsed
        currentSpeed = Mathf.Min(speed + Time.timeSinceLevelLoad * speedIncreasePerSecond, maxSpeed);

        // Check if it's time to spawn a new pipe
        if (Time.time - lastSpawnTime >= spawnDelay)
        {
            lastSpawnTime = Time.time;

            // Calculate the height of the top and bottom pipes
            float topPipeHeight = Random.Range(pipeMinHeight, pipeMaxHeight - pipeGap);
            float bottomPipeHeight = topPipeHeight + pipeGap;

            // Spawn the top pipe
            Vector3 topPipePosition = new Vector3(spawnPosition, topPipeHeight, 0f);
            GameObject topPipe = Instantiate(pipePrefab, topPipePosition, Quaternion.identity);

            // Spawn the bottom pipe
            Vector3 bottomPipePosition = new Vector3(spawnPosition, bottomPipeHeight, 0f);
            GameObject bottomPipe = Instantiate(pipePrefab, bottomPipePosition, Quaternion.identity);

            // Set the speed and despawn position of the pipes
            PipeMovement topPipeMovement = topPipe.GetComponent<PipeMovement>();
            topPipeMovement.speed = currentSpeed;
            topPipeMovement.despawnPosition = despawnPosition;

            PipeMovement bottomPipeMovement = bottomPipe.GetComponent<PipeMovement>();
            bottomPipeMovement.speed = currentSpeed;
            bottomPipeMovement.despawnPosition = despawnPosition;

            // Flip the bottom pipe vertically
            bottomPipe.transform.localScale = new Vector3(1f, -1f, 1f);
        }
    }
}
