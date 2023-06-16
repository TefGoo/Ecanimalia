using UnityEngine;

public class SpriteClickHandler : MonoBehaviour
{
    public RandomSpawner randomSpawner; // Reference to the RandomSpawner script

    private void OnMouseDown()
    {
        randomSpawner.DestroySprite(gameObject, true); // Pass 'true' to indicate destruction by click
    }

}
