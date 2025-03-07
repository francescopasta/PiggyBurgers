using System.Collections.Generic;
using UnityEngine;

public class FoodStorage : MonoBehaviour
{
    public int totalScore;
    public Dictionary<string, int> fruitToPoint;
    void Start()
    {
        fruitToPoint = new Dictionary<string, int>
        {
            { "Watermelon", -2 },
            { "Cherry", -2 },
            { "Banana", 7 }
        };
    }

}
