using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private ButtonClickScript buttonClickScript;
    private string currentbutton = "start";

    [SerializeField]
    private GameObject buttonContainer; 
    
    [Header("Animation Settings")]

    [SerializeField] private float delay = 1f;
    [SerializeField] private float delay2 = 2f; 
    [SerializeField] private float delay3 = 3f;           // How long to wait
    [SerializeField] private GameObject[] anim1; // Objects to set active/inactive
    [SerializeField] private GameObject[] anim2;
      [SerializeField] private GameObject[] anim3;
    [SerializeField] private bool setActiveState = true; // True = activate, False = deactivate

    private float timer;
 
    private bool running = false;


    //Button pressed handler
    public void openTarget(string buttonPressed)
    {
        Debug.Log("openTarget called by: " + buttonPressed);
        currentbutton = buttonPressed;
        if (currentbutton == "UnityPortfolioButton")
        {
            Debug.Log("openTarget called by: " + buttonPressed);
        }
        if (currentbutton == "SoundDesignPortfolioButton")
        {
            Debug.Log("openTarget called by: " + buttonPressed);

        }
        if (currentbutton == "PhysicalToysPortfolioButton")
        {
            Debug.Log("openTarget called by: " + buttonPressed);

        }
        if (currentbutton == "ReturnToMainMenuButton")
        {
            Debug.Log("openTarget called by: " + buttonPressed);

        }
    }
    
    //Animation 
  void Update()
    {
        timer += Time.deltaTime;

        if (timer >= delay)
        {
            ToggleObjectsAnim1();
        }
        if (timer >= delay2)
        {
            ToggleObjectsAnim2();
        }
        if (timer >= delay3)    
        {
            ToggleObjectsAnim3();
            ToggleButtonContainer();
            running = false; // stop after triggering
        }
    }

    private void ToggleObjectsAnim1()
    {
        foreach (var obj in anim1)
        {
            if (obj != null)
                obj.SetActive(setActiveState);
        }
    }
    private void ToggleObjectsAnim2()
    {
        foreach (var obj in anim2)
        {
            if (obj != null)
                obj.SetActive(setActiveState);
        }
    }
    private void ToggleObjectsAnim3()
    {
        foreach (var obj in anim3)
        {
            if (obj != null)
                obj.SetActive(setActiveState);
        }
    }
    
    private void ToggleButtonContainer()
    {
        
            buttonContainer.SetActive(true);
        
    }

    // --- Public Controls ---
    public void StartTimer()
    {
        timer = 0f;
        running = true;
    }

    public void ResetTimer()
    {
        timer = 0f;
        running = false;
    }

    public void StopTimer()
    {
        running = false;
    }
 
}

