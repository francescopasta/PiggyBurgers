using UnityEngine;
using UnityEngine.UI;

public class FillBarScript : MonoBehaviour
{
    public Image fillbar; // The UI Image to update the fill
    public BellyExploding bellyExploding;

    void Update()
    {
        // Get the totalScore from BellyExploding
        float totalScore = bellyExploding.totalScore;

        // Normalize the totalScore to a value between 0 and 1
        // First, make sure the score is clamped between 68 and 130
        float normalizedScore = Mathf.Clamp01((totalScore - 68f) / (130f - 68f));

        // Update the fill amount of the slider (or fillbar)
        fillbar.fillAmount = normalizedScore;
    }
}
