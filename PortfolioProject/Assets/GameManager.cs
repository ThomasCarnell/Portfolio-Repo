using UnityEngine;

public class GameManager : MonoBehaviour
{
    private string currentbutton = "start";
    public void openTarget(string buttonPressed)
    {
        Debug.Log("openTarget called by: " + buttonPressed);
        currentbutton = buttonPressed;
        if (currentbutton == "UnityPortfolioButton")
        {
        }
        if (currentbutton == "SoundDesignPortfolioButton")
        {
        }
    }
 
}

