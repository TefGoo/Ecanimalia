using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject[] carPrefabs;
    public float minSpawnInterval = 1f;
    public float maxSpawnInterval = 3f;
    public float minSpawnSpeed = 0.5f;
    public float maxSpawnSpeed = 2f;
    public float spawnOffset = 0f;
    public float spawnDirection = 1f;

    private float timer = 0f;
    private float spawnInterval;
    private float spawnSpeed;


    void Start()
    {
        CalculateSpawnInterval();
        CalculateSpawnSpeed();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer -= spawnInterval;
            SpawnCar();
            CalculateSpawnInterval();
            CalculateSpawnSpeed();
        }
    }

    void SpawnCar()
    {
        int randomIndex = Random.Range(0, carPrefabs.Length);
        GameObject car = Instantiate(carPrefabs[randomIndex], transform.position + new Vector3(spawnOffset * spawnDirection, 0f, 0f), Quaternion.identity);
        car.GetComponent<CarController>().moveSpeed = spawnSpeed * spawnDirection;
    }

    void CalculateSpawnInterval()
    {
        spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    void CalculateSpawnSpeed()
    {
        spawnSpeed = Random.Range(minSpawnSpeed, maxSpawnSpeed);
    }
}
