using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public int damageAmount = 1;  // Amount of damage inflicted on the player

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Inflict damage to the player (whale)
            WhaleHealth playerHealth = collision.GetComponent<WhaleHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }

            // Destroy the obstacle
            Destroy(gameObject);
        }
    }
}
