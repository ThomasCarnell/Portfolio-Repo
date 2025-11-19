using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PortfolioManager : MonoBehaviour
{
    [Header("Portfolio Setup")]
    [SerializeField] private List<PortfolioEntry> entries_unity = new();
    [SerializeField] private List<PortfolioEntry> entries_soundDesign = new();
        [SerializeField] private List<PortfolioEntry> entries_physical = new();
        [SerializeField] private List<PortfolioEntry> entries_start = new();

    [SerializeField] private Transform uiParent;
    [SerializeField] private GameObject entryUIPrefab;

    [Header("UI Navigation")]
    [SerializeField] private Button nextButton;
    [SerializeField] private Button previousButton;

    private List<GameObject> spawnedEntries = new();
    private int currentIndex = 0;

    private bool isUnityPortfolio = false;
    private bool isSoundDesignPortfolio = false;
    private bool isPhysicalPortfolio = false;
    private bool isStartPortfolio = false;

    void Start()
    {
        Debug.Log($"📁 PortfolioManager ready — entries: {entries_unity.Count}");

        // Hook up buttons
        if (nextButton != null)
            nextButton.onClick.AddListener(ShowNextEntry);

        if (previousButton != null)
            previousButton.onClick.AddListener(ShowPreviousEntry);

            ShowEntry_start(0);
    }
        //FOR UNITY PORTFOLIO
    public void ShowEntry_unity(int index)
    {
        ClearPortfolio();
        isUnityPortfolio = true;
        if (index < 0 || index >= entries_unity.Count)
        {
            Debug.LogWarning("⚠️ Invalid entry index.");
            return;
        }

        var entry = entries_unity[index];
        GameObject ui = Instantiate(entryUIPrefab, uiParent);
        var display = ui.GetComponent<PortfolioDisplay>();

        if (display != null)
            display.SetEntry(entry);

        spawnedEntries.Add(ui);

        Debug.Log($"🖼️ Showing entry {index + 1}/{entries_unity.Count}: {entry.projectName}");

        UpdateButtonStates();
    }
        //FOR SOUND DESIGN PORTFOLIO
        public void ShowEntry_soundDesign(int index)
    {
        ClearPortfolio();
        isSoundDesignPortfolio = true;
        if (index < 0 || index >= entries_soundDesign.Count)
        {
            Debug.LogWarning("⚠️ Invalid entry index.");
            return;
        }

        var entry = entries_soundDesign[index];
        GameObject ui = Instantiate(entryUIPrefab, uiParent);
        var display = ui.GetComponent<PortfolioDisplay>();

        if (display != null)
            display.SetEntry(entry);

        spawnedEntries.Add(ui);

        Debug.Log($"🖼️ Showing entry {index + 1}/{entries_soundDesign.Count}: {entry.projectName}");

        UpdateButtonStates();
    }
        //FOR PHYSICAL TOYS PORTFOLIO
  public void ShowEntry_physical(int index)
    {
        ClearPortfolio();
        isPhysicalPortfolio = true;
        if (index < 0 || index >= entries_physical.Count)
        {
            Debug.LogWarning("⚠️ Invalid entry index.");
            return;
        }

        var entry = entries_physical[index];
        GameObject ui = Instantiate(entryUIPrefab, uiParent);
        var display = ui.GetComponent<PortfolioDisplay>();

        if (display != null)
            display.SetEntry(entry);

        spawnedEntries.Add(ui);

        Debug.Log($"🖼️ Showing entry {index + 1}/{entries_physical.Count}: {entry.projectName}");

        UpdateButtonStates();
    }

      public void ShowEntry_start(int index)
    {
        ClearPortfolio();
        isStartPortfolio = true;
        if (index < 0 || index >= entries_start.Count)
        {
            Debug.LogWarning("⚠️ Invalid entry index.");
            return;
        }

        var entry = entries_start[index];
        GameObject ui = Instantiate(entryUIPrefab, uiParent);
        var display = ui.GetComponent<PortfolioDisplay>();

        if (display != null)
            display.SetEntry(entry);

        spawnedEntries.Add(ui);

        Debug.Log($"🖼️ Showing entry {index + 1}/{entries_start.Count}: {entry.projectName}");

        UpdateButtonStates();
    }

    private void UpdateButtonStates()
    {
        if (previousButton != null)
            previousButton.interactable = currentIndex > 0;

        if (isUnityPortfolio)
        {
            if (nextButton != null)
                nextButton.interactable = currentIndex < entries_unity.Count - 1;
            return;
        }
        if (isSoundDesignPortfolio)
        {
            if (nextButton != null)
                nextButton.interactable = currentIndex < entries_soundDesign.Count - 1;
            return;
        }
        if (isPhysicalPortfolio)
        {
            if (nextButton != null)
                nextButton.interactable = currentIndex < entries_physical.Count - 1;
            return;
        }
    }

    public void ShowNextEntry()
    {
        if (entries_unity.Count == 0 || currentIndex >= entries_unity.Count - 1)
            return;
        currentIndex++;
        if (isUnityPortfolio)
        ShowEntry_unity(currentIndex);

        if(entries_soundDesign.Count == 0 || currentIndex >= entries_soundDesign.Count - 1)
            return; 
            currentIndex++;
        if(isSoundDesignPortfolio)
            ShowEntry_soundDesign(currentIndex);

        if(entries_physical.Count == 0 || currentIndex >= entries_physical.Count - 1)
            return; 
            currentIndex++;
        if(isPhysicalPortfolio)
            ShowEntry_physical(currentIndex);
    }

    public void ShowPreviousEntry()
    {
        if (entries_unity.Count == 0 || currentIndex <= 0)
            return;

        currentIndex--;
        if (isUnityPortfolio)
        ShowEntry_unity(currentIndex);

        if (entries_soundDesign.Count == 0 || currentIndex <= 0)
            return;
        currentIndex--;
        if (isSoundDesignPortfolio)
            ShowEntry_soundDesign(currentIndex);

        if (entries_physical.Count == 0 || currentIndex <= 0)
            return;
        currentIndex--;
        if (isPhysicalPortfolio)
            ShowEntry_physical(currentIndex);   
       
    }

    public void ClearPortfolio()
    {
        foreach (var e in spawnedEntries)
        {
            if (e != null)
                Destroy(e);
        }
        spawnedEntries.Clear();

    }
    public void ResetCurrentIndex()
    {
        currentIndex = 0;
        ButtonReset();
    }

    private void ButtonReset()
    {
        isPhysicalPortfolio = false;
        isSoundDesignPortfolio = false;
        isUnityPortfolio = false;
        isStartPortfolio = true;
    }
}
