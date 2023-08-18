using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject groundObstaclePrefab;
    public GameObject floatingObstaclePrefab;
    public Transform obstacleParent;
    public float groundLevel;
    public float spawnInterval;
    public float minSpeed;
    public float maxSpeed;
    public AudioClip floatingObstacleSpawnSound;

    [SerializeField] private AudioSource soundManagerAudioSource; // Reference to the SoundManager's AudioSource

    private void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    private IEnumerator SpawnObstacles()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            spawnInterval = Random.Range(2.3f, 3f);

            GameObject obstaclePrefab = Random.Range(0, 2) == 0 ? groundObstaclePrefab : floatingObstaclePrefab;
            float speed = Random.Range(minSpeed, maxSpeed);

            Vector3 spawnPosition = transform.position;
            float[] floatingHeights = new float[] { -4f, -3f, -2f };
            spawnPosition.y = obstaclePrefab == groundObstaclePrefab ? groundLevel : floatingHeights[Random.Range(0, floatingHeights.Length)];

            GameObject obstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity, obstacleParent);
            obstacle.GetComponent<ObstacleMovement>().Initialize(speed);

            if (obstaclePrefab == floatingObstaclePrefab && soundManagerAudioSource != null && floatingObstacleSpawnSound != null)
            {
                soundManagerAudioSource.PlayOneShot(floatingObstacleSpawnSound);
            }
        }
    }
}
