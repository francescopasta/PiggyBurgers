using UnityEngine;
using System.Collections;

public class SpawnObjects : MonoBehaviour
{
    public GameObject[] objectsToSpawn;  // Array of objects to spawn
    public float spawnY = 1.35f;         // Y position for spawn
    public float spawnZ = 0f;            // Z position for spawn (fixed at 0)
    public float xStartPosition = -1.6f; // Starting X position
    public float xOffset = 0.9f;         // Distance between spawned objects on the X axis
    public float spawnInterval = 1f;     // Time interval between each spawn (in seconds)

    void Start()
    {
        // Automatically start spawning objects when the game starts
        StartCoroutine(SpawnWithInterval());
    }

    // Coroutine to spawn objects with a set interval
    IEnumerator SpawnWithInterval()
    {
        // Run the spawning forever
        while (true)
        {
            // Random number of objects to spawn (between 3 and 7)
            int numberToSpawn = Random.Range(3, 8); // Random count between 3 and 7

            // Select a random set of objects from the array
            GameObject[] selectedObjects = GetRandomObjects(numberToSpawn);

            // Shuffle the positions for randomness
            float[] xPositions = GenerateXPositions(selectedObjects.Length);
            Shuffle(xPositions);

            // Spawn each object at the randomized positions with the given interval
            for (int i = 0; i < selectedObjects.Length; i++)
            {
                Instantiate(selectedObjects[i], new Vector3(xPositions[i], spawnY, spawnZ), Quaternion.identity);
            }

            // Wait for the specified interval before spawning the next batch
            yield return new WaitForSeconds(spawnInterval);
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

    // Generate X positions for the number of objects to spawn
    float[] GenerateXPositions(int numObjects)
    {
        float[] xPositions = new float[numObjects];
        for (int i = 0; i < numObjects; i++)
        {
            xPositions[i] = xStartPosition + i * xOffset;
        }
        return xPositions;
    }

    // Get a random set of objects to spawn
    GameObject[] GetRandomObjects(int numberToSpawn)
    {
        GameObject[] selectedObjects = new GameObject[numberToSpawn];
        bool[] usedIndices = new bool[objectsToSpawn.Length];

        for (int i = 0; i < numberToSpawn; i++)
        {
            int randomIndex;
            do
            {
                randomIndex = Random.Range(0, objectsToSpawn.Length);
            } while (usedIndices[randomIndex]); // Ensure the object is not selected more than once

            selectedObjects[i] = objectsToSpawn[randomIndex];
            usedIndices[randomIndex] = true; // Mark the object as used
        }

        return selectedObjects;
    }
}
