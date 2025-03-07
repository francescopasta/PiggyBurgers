using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{
    public float explosionForce = 10f;  // Force of the explosion
    public float explosionRadius = 5f;  // Radius of the explosion effect
    public float torqueForce = 5f;      // Torque applied to objects
    public float minTimeInterval = 1f;  // Minimum time interval for explosion
    public float maxTimeInterval = 3f;  // Maximum time interval for explosion

    void Start()
    {
        // Start the coroutine to trigger the explosion with a random time interval
        StartCoroutine(TriggerExplosionWithRandomInterval());
    }

    // Coroutine to wait for a random time interval between minTimeInterval and maxTimeInterval
    IEnumerator TriggerExplosionWithRandomInterval()
    {
        while (true)
        {
            // Wait for a random time between the min and max time intervals
            float randomWaitTime = Random.Range(minTimeInterval, maxTimeInterval);
            yield return new WaitForSeconds(randomWaitTime);

            // Trigger explosion after the wait time
            Explode();
        }
    }

    // Perform the explosion effect
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(Vector3.up * explosionForce, ForceMode.Impulse);

                // Optionally, apply torque to make the object spin
                //Vector3 randomTorque = new Vector3(
                //    Random.Range(-torqueForce, torqueForce),
                //    Random.Range(-torqueForce, torqueForce),
                //    Random.Range(-torqueForce, torqueForce)
                //);

                //rb.AddTorque(randomTorque, ForceMode.Impulse);
            }
        }
    }
}
