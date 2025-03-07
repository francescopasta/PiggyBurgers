using UnityEngine;

public class DestroyFood : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
