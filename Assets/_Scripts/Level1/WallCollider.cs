using UnityEngine;

public class WallCollider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Set isTrigger property to true to allow other colliders to pass through
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
}
