using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float explosionForce = 10f;
    public float explosionRadius = 5f;
    public float torqueForce = 5f;

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
