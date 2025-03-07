using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellyExploding : MonoBehaviour
{
    public int totalScore;
    public Dictionary<string, int> fruitToPoint;

    public GameObject pig;

    void Start()
    {
        fruitToPoint = new Dictionary<string, int>
        {
            { "Watermelon", -2 },
            { "Cherry", -2 },
            { "Banana", 7 }
        };
        StartCoroutine(RemoveMass());
    }

    public void AddMass(int mass)
    {
        transform.localScale += mass * new Vector3(1, 1, 1);
    }

    IEnumerator RemoveMass()
    {
        if(totalScore > -8)
        {
            yield return new WaitForSeconds(5);
            totalScore -= 2;
            transform.localScale += totalScore * new Vector3(1, 1, 1);
            StartCoroutine(RemoveMass());
        } else
        {
            pig.SetActive(false);
        }
    }
}
