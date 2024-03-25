using UnityEngine;

public class DamageZoneSpawner : MonoBehaviour
{
    public GameObject damageZonePrefab;
    public float spawnInterval = 5.0f;
    public int damageAmount = 1;
    public float activeDuration = 3.0f;  // Duration for which the damage zone remains active
    public Transform[] spawnPoints;

    private void Start()
    {
        InvokeRepeating("SpawnDamageZone", 0.0f, spawnInterval);
    }

    private void SpawnDamageZone()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogWarning("No spawn points assigned to the DamageZoneSpawner.");
            return;
        }

        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform selectedSpawnPoint = spawnPoints[randomIndex];

        GameObject damageZone = Instantiate(damageZonePrefab, selectedSpawnPoint.position, Quaternion.identity);
        damageZone.transform.SetParent(transform);

        Destroy(damageZone, activeDuration); // Destroy the damage zone after the active duration
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Whale entered a damage zone.");
            WhaleHealth whaleHealth = other.GetComponent<WhaleHealth>();
            if (whaleHealth != null)
            {
                whaleHealth.TakeDamage(damageAmount);
            }
        }
    }
}
