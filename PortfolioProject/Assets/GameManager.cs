using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private ButtonClickScript buttonClickScript;
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
        if (currentbutton == "PhysicalToysPortfolioButton")
        {
        } 
        if (currentbutton == "ReturnToMainMenuButton")
        {
            buttonClickScript.EnableButtons();
        }
    }
 
}

