using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float explosionForce = 10f; // Adjust force for how high objects go
    public float explosionRadius = 5f; // Area of effect

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Explode();
        }
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(Vector3.up * explosionForce, ForceMode.Impulse);
            }
        }
    }
}
