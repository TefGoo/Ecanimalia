using UnityEngine;

public class SceneSpeedManager : MonoBehaviour
{
    public float accelerationRate = 0.1f; // The rate at which the speed increases per second
    public float maxSpeed = 10.0f; // The maximum speed the scene can reach

    private float currentSpeed = 0.0f;

    private void Start()
    {
        currentSpeed = Time.timeScale;
    }

    private void Update()
    {
        // Increase the speed based on the acceleration rate
        currentSpeed += accelerationRate * Time.deltaTime;

        // Clamp the speed to the maximum speed
        currentSpeed = Mathf.Clamp(currentSpeed, Time.timeScale, maxSpeed);

        // Apply the new speed to the time scale
        Time.timeScale = currentSpeed;
    }
}
