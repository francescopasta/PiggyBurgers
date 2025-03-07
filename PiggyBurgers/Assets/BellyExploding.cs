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
        totalScore = (int)transform.localScale.x;
        fruitToPoint = new Dictionary<string, int>
        {
            { "Watermelon", -1 },
            { "Cherry", -1 },
            { "Banana", 2 },
            { "Cheese", 1 },
            { "Olive", 1 },
            { "Hamburger", 2 },
            { "Hotdog", 2 }
        };
        StartCoroutine(RemoveMass());
    }

    private void Update()
    {
        //if(totalScore > 10)
        //{
        //    pig.SetActive(false);
        //}
    }

    public void AddMass()
    {
        transform.localScale = totalScore * new Vector3(1, 1, 1);
    }

    IEnumerator RemoveMass()
    {
        if(totalScore > 0 || totalScore < 0)
        {
            yield return new WaitForSeconds(2);
            totalScore -= 2;
            transform.localScale = totalScore * new Vector3(1, 1, 1);
            StartCoroutine(RemoveMass());
        } else
        {
            pig.SetActive(false);
        }
    }
}
