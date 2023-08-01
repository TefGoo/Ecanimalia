using UnityEngine;

public class SpriteClickHandler : MonoBehaviour
{
    public RandomSpawner randomSpawner; // Reference to the RandomSpawner script

    private void OnMouseDown()
    {
        if (!randomSpawner.spawnerReady)
        {
            // If the spawner is not ready, the sprite shouldn't be clickable
            return;
        }

        randomSpawner.DestroySprite(gameObject, true); // Pass 'true' to indicate destruction by click
    }
}
