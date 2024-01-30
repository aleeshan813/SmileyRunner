using TMPro;
using UnityEngine;

public class Points : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pointstext;
    int points = 0;

    // Call this method to update and display the points
    public void UpdatePoints(int newPoints)
    {
        points = newPoints;
        UpdatePointsText();
    }

    // Update the TextMeshProUGUI component with the current points
    void UpdatePointsText()
    {
        if (pointstext != null)
        {
            pointstext.text = ""+ points.ToString();
        }
    }
}
