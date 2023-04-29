using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject carPrefab;
    public float spawnInterval = 2f;
    public float spawnSpeed = 1f;
    public float spawnOffset = 0f;
    public float spawnDirection = 1f;

    private float timer = 0f;


    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer -= spawnInterval;
            SpawnCar();
        }
    }

    void SpawnCar()
    {
        GameObject car = Instantiate(carPrefab, transform.position + new Vector3(spawnOffset * spawnDirection, 0f, 0f), Quaternion.identity);
        car.GetComponent<CarController>().moveSpeed = spawnSpeed * spawnDirection;
    }
}
