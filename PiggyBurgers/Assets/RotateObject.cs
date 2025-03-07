using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 50f;

    void Update()
    {
        transform.Rotate(new Vector3(1, 1, 1) * rotationSpeed * Time.deltaTime);
    }
}
