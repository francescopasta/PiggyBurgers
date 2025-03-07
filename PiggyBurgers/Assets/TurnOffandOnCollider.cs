using UnityEngine;

public class ColliderToggle : MonoBehaviour
{
    public float toggleInterval = 2f;  // Time interval (in seconds) to toggle the collider
    private Collider objectCollider;   // Reference to the object's collider
    private bool isColliderEnabled;    // Boolean to track if the collider is currently enabled

    void Start()
    {
        // Get the collider component on the object this script is attached to
        objectCollider = GetComponent<Collider>();

        // Set initial state for the collider
        if (objectCollider != null)
        {
            isColliderEnabled = objectCollider.enabled;
            InvokeRepeating("ToggleCollider", 0f, toggleInterval); // Call ToggleCollider repeatedly
        }
        else
        {
            Debug.LogWarning("Collider not found on " + gameObject.name);
        }
    }

    // Method to toggle the collider's enabled state
    void ToggleCollider()
    {
        if (objectCollider != null)
        {
            isColliderEnabled = !isColliderEnabled; // Toggle the state
            objectCollider.enabled = isColliderEnabled; // Apply the new state
        }
    }
}
