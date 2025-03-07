using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;

public class ClickFruitScript : MonoBehaviour
{
    public string fruitTag;
    public FoodStorage fruitStorage;
    
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
                fruitStorage.totalScore += fruitStorage.fruitToPoint[fruit];
            }
        }
    }
}
