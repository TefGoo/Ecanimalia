using UnityEngine;

public class ActivateObjectOnEnter : MonoBehaviour
{
    public GameObject objectToActivate;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (objectToActivate != null)
            {
                objectToActivate.SetActive(true);
                Debug.Log("Activated object: " + objectToActivate.name);
            }
            else
            {
                Debug.LogWarning("Object to activate is not assigned!");
            }
        }
    }
}
