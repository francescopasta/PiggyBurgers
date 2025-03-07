using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public GameObject[] objectsToSpawn;  // Array of objects to spawn
    public float spawnY = 1.35f;         // Y position for spawn
    public float spawnZ = 0f;            // Z position for spawn (fixed at 0)
    public float xStartPosition = -1.6f; // Starting X position
    public float xOffset = 0.9f;         // Distance between spawned objects on the X axis

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SpawnObjectsInRandomOrder();
        }
    }

    void SpawnObjectsInRandomOrder()
    {
        // Get the number of objects to spawn
        int numberOfObjects = objectsToSpawn.Length;

        // Generate an array of X positions based on the number of objects
        float[] xPositions = new float[numberOfObjects];
        for (int i = 0; i < numberOfObjects; i++)
        {
            xPositions[i] = xStartPosition + i * xOffset;
        }

        // Shuffle the X positions to randomize the order
        Shuffle(xPositions);

        // Spawn the objects at the randomized positions
        for (int i = 0; i < numberOfObjects; i++)
        {
            GameObject spawnedObject = Instantiate(objectsToSpawn[i], new Vector3(xPositions[i], spawnY, spawnZ), Quaternion.identity);
        }
    }

    // Shuffle an array using the Fisher-Yates shuffle algorithm
    void Shuffle(float[] array)
    {
        int n = array.Length;
        for (int i = n - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            float temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
