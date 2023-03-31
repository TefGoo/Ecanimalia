using UnityEngine;

public class CrossyMovement : MonoBehaviour
{
    public float moveDistance = 3f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(new Vector2(0f, moveDistance));
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Translate(new Vector2(0f, -moveDistance));
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(new Vector2(-moveDistance, 0f));
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(new Vector2(moveDistance, 0f));
        }
    }
}
