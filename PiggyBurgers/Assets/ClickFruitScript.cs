using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;

public class ClickFruitScript : MonoBehaviour
{
    public string fruitTag;
    public BellyExploding fruitStorage;
    public float moveDuration = 1.5f; // Time it takes to move to center
    //public Transform target;
    

    private void Start()
    {
        fruitTag = gameObject.tag;
    }
    private void OnMouseDown()
    {
        foreach (string fruit in fruitStorage.fruitToPoint.Keys)
        {
            if (fruit == gameObject.tag)
            {
                StartCoroutine(MoveToCenterRoutine());
                fruitStorage.totalScore += fruitStorage.fruitToPoint[fruit];
                fruitStorage.AddMass();
            }
        }
    }
    IEnumerator MoveToCenterRoutine()
    {
        Vector3 start = transform.position;
        Vector3 target = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane + 2f));
        Vector3 startScale = transform.localScale;

        float time = 0;
        while (time < moveDuration)
        {
            float t = time / moveDuration;
            transform.position = Vector3.Lerp(start, target, t);
            transform.localScale = Vector3.Lerp(startScale, Vector3.zero, t);
            time += Time.deltaTime;
            yield return null;
        }

        transform.position = target;
        transform.localScale = Vector3.zero;

        Destroy(gameObject); // Remove the fruit
    }
}
