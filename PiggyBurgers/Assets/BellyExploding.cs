using System.Collections;
using UnityEngine;

public class BellyExploding : MonoBehaviour
{
    public int totalScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(RemoveMass());
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    IEnumerator RemoveMass()
    {
        if(totalScore > -8)
        {
            yield return new WaitForSeconds(5);
            totalScore -= 2;
            transform.localScale += totalScore * new Vector3(1, 1, 1);
            StartCoroutine(RemoveMass());
        }
    }
}
