//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private ButtonClickScript buttonClickScript;
    private string currentbutton = "start";
    [SerializeField] private PortfolioManager portfolioManager;

    [SerializeField]
    private GameObject buttonContainer;
    [SerializeField]
    private GameObject portfolioTextButtonContainer;
    [SerializeField]
    private GameObject returnButtonText;
    [SerializeField]
    private GameObject returnButton;
    [SerializeField]
    private GameObject nextPreviousButtons;
    [SerializeField]
    private GameObject selectionTarget;
    private GameObject startPosPortfolio;

    private GameObject instanceReturnButtonText;
    
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
    private bool returnButtonActive = false;

    //Button pressed handler
    public void openTarget(string buttonPressed)
    {
        currentbutton = buttonPressed;
        if (currentbutton == "UnityPortfolioButton")
        {
            instanceReturnButtonText = Instantiate(returnButtonText, transform.position, transform.rotation);
            instanceReturnButtonText.GetComponent<AttachToObject>().target = returnButton.transform;
            anim3[0].GetComponent<FadeMaterialDirect>().FadeOut();
            anim3[1].GetComponentInChildren<OrderableText>().EnableGravity();
            anim3[2].GetComponentInChildren<OrderableText>().EnableGravity();

            buttonContainer.GetComponent<ButtonResetAnimation>().StartReverseScaling();
            returnButtonActive = true;

            portfolioManager.ShowEntry_unity(0); // Show first portfolio entry
            nextPreviousButtons.SetActive(true);

        }
        if (currentbutton == "SoundDesignPortfolioButton")
        {
            instanceReturnButtonText = Instantiate(returnButtonText, transform.position, transform.rotation);
            instanceReturnButtonText.GetComponent<AttachToObject>().target = returnButton.transform;
            anim3[1].GetComponent<FadeMaterialDirect>().FadeOut();
            anim3[0].GetComponentInChildren<OrderableText>().EnableGravity();
            anim3[2].GetComponentInChildren<OrderableText>().EnableGravity();

            buttonContainer.GetComponent<ButtonResetAnimation>().StartReverseScaling();
            returnButtonActive = true;
                        nextPreviousButtons.SetActive(true);

            portfolioManager.ShowEntry_soundDesign(0); // Show first portfolio entry
        }
        if (currentbutton == "PhysicalToysPortfolioButton")
        {
            instanceReturnButtonText = Instantiate(returnButtonText, transform.position, transform.rotation);
            instanceReturnButtonText.GetComponent<AttachToObject>().target = returnButton.transform;
            anim3[2].GetComponent<FadeMaterialDirect>().FadeOut();
            anim3[0].GetComponentInChildren<OrderableText>().EnableGravity();
            anim3[1].GetComponentInChildren<OrderableText>().EnableGravity();
            buttonContainer.GetComponent<ButtonResetAnimation>().StartReverseScaling();
            returnButtonActive = true;
                        nextPreviousButtons.SetActive(true);

            portfolioManager.ShowEntry_physical(0); // Show first portfolio entry
        }
        if (currentbutton == "ReturnToMainMenuButton" && returnButtonActive == true)
        {
            portfolioTextButtonContainer.SetActive(true);
            returnButtonClicked();
            buttonContainer.GetComponent<ButtonResetAnimation>().StartScaling();
            anim3[0].GetComponentInChildren<OrderableText>().DisableGravity();
            anim3[1].GetComponentInChildren<OrderableText>().DisableGravity();
            anim3[2].GetComponentInChildren<OrderableText>().DisableGravity();

            anim3[0].GetComponent<FadeMaterialDirect>().FadeIn();
            anim3[1].GetComponent<FadeMaterialDirect>().FadeIn();
            anim3[2].GetComponent<FadeMaterialDirect>().FadeIn();
            returnButtonActive = false;
                        nextPreviousButtons.SetActive(false);
        portfolioManager.ShowEntry_start(0); // Show first portfolio entry
        }
    }
    private void returnButtonClicked()
    {

          if (instanceReturnButtonText == null) return;
        
        // enable OrderableText gravity if present
        var orderable = instanceReturnButtonText.GetComponent<OrderableText>();
        if (orderable != null) orderable.EnableGravity();

        // find or add rigidbodies on the root and all children
        Rigidbody[] rbs = instanceReturnButtonText.GetComponentsInChildren<Rigidbody>(true);
        if (rbs == null || rbs.Length == 0)
        {
            // ensure there's at least one rigidbody on the root
            var rootRb = instanceReturnButtonText.GetComponent<Rigidbody>();
            if (rootRb == null) rootRb = instanceReturnButtonText.AddComponent<Rigidbody>();
            rbs = new Rigidbody[] { rootRb };
        }

        // explosion-like random impulse parameters
        float forceMin = 2f;
        float forceMax = 3f;
        float radius = 3f;
        float upwardsModifier = -0.1f;

        Vector3 explosionCenter = instanceReturnButtonText.transform.position;

        foreach (var rb in rbs)
        {
            if (rb == null) continue;

            rb.isKinematic = false;
            rb.useGravity = true;

            // randomize force and a slightly offset center so pieces scatter nicely
            float force = Random.Range(forceMin, forceMax);
            Vector3 centerOffset = explosionCenter + Random.insideUnitSphere * 0.5f;
            rb.AddExplosionForce(force, centerOffset, radius, upwardsModifier, ForceMode.Impulse);

        }

        Destroy(instanceReturnButtonText, 2f);

    }
    void Start()
    {
        running = true;
    }

    //Animation 
    void Update()
    {
        if (running)
        {
                    timer += Time.deltaTime;
        }

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
            StopTimer();
            ResetTimer();
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
    public void DisablePortfolioTextButtonContainer()
    {
        portfolioTextButtonContainer.SetActive(false);
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

