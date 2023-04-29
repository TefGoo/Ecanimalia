using UnityEngine;

public class CarController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float respawnTime = 2f;
    public float moveDirection = 1f;

    private Vector2 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.Translate(new Vector2(moveDirection * moveSpeed * Time.deltaTime, 0f));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boundary"))
        {
            Respawn();
        }
    }

    void Respawn()
    {
        transform.position = startPos;
    }
}
