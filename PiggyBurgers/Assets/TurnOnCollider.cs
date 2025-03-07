using UnityEngine;
using System.Collections;

public class TimedColliderEnable : MonoBehaviour
{
    public float delayTime = 2f;             // Time in seconds before enabling the collider
    public string destroyTag = "Platform";   // The tag of objects that will trigger destruction
    public Collider specificCollider;       // The specific collider to enable (assigned in the Inspector)

    void Start()
    {
        // Ensure the specific collider is initially disabled
        if (specificCollider != null)
        {
            specificCollider.enabled = false;  // Disable the specific collider initially
        }

        // Start the coroutine to enable the collider after the delay
        StartCoroutine(EnableColliderAfterTime());
    }

    // Coroutine to enable the collider after a specified delay time
    IEnumerator EnableColliderAfterTime()
    {
        // Wait for the specified time (delayTime)
        yield return new WaitForSeconds(delayTime);

        // Enable the specific collider after the delay
        if (specificCollider != null)
        {
            specificCollider.enabled = true;
        }
    }

    // Trigger detection with objects and check for the correct tag
    void OnTriggerEnter(Collider other)
    {
        // Only destroy if the collider has been enabled and the tag matches
        if (specificCollider.enabled && other.CompareTag(destroyTag))
        {
            // Destroy the object when it enters the trigger and has the specified tag
            Destroy(gameObject);
        }
    }
}
