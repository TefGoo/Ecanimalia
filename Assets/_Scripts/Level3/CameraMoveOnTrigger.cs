using UnityEngine;

public class CameraMoveOnTrigger : MonoBehaviour
{
    public float yOffset = 27f;

    private bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasTriggered && other.CompareTag("Player"))
        {
            hasTriggered = true;
            Camera.main.transform.Translate(new Vector3(0f, yOffset, 0f));
            //gameObject.SetActive(false);
        }
    }
}
