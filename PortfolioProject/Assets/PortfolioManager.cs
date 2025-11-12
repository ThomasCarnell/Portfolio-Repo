using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PortfolioManager : MonoBehaviour
{
    [Header("Portfolio Setup")]
    [SerializeField] private List<PortfolioEntry> entries = new();
    [SerializeField] private Transform uiParent;
    [SerializeField] private GameObject entryUIPrefab;

    [Header("UI Navigation")]
    [SerializeField] private Button nextButton;
    [SerializeField] private Button previousButton;

    private List<GameObject> spawnedEntries = new();
    private int currentIndex = 0;

    void Start()
    {
        Debug.Log($"📁 PortfolioManager ready — entries: {entries.Count}");

        // Hook up buttons
        if (nextButton != null)
            nextButton.onClick.AddListener(ShowNextEntry);

        if (previousButton != null)
            previousButton.onClick.AddListener(ShowPreviousEntry);

        // Start with first entry if available
        // if (entries.Count > 0)
        //     ShowEntry(0);
    }

    public void ShowEntry(int index)
    {
        ClearPortfolio();

        if (index < 0 || index >= entries.Count)
        {
            Debug.LogWarning("⚠️ Invalid entry index.");
            return;
        }

        var entry = entries[index];
        GameObject ui = Instantiate(entryUIPrefab, uiParent);
        var display = ui.GetComponent<PortfolioDisplay>();

        if (display != null)
            display.SetEntry(entry);

        spawnedEntries.Add(ui);

        Debug.Log($"🖼️ Showing entry {index + 1}/{entries.Count}: {entry.projectName}");

        UpdateButtonStates();
    }

    private void UpdateButtonStates()
    {
        if (previousButton != null)
            previousButton.interactable = currentIndex > 0;

        if (nextButton != null)
            nextButton.interactable = currentIndex < entries.Count - 1;
       
    }

    public void ShowNextEntry()
    {
        if (entries.Count == 0 || currentIndex >= entries.Count - 1)
            return;

        currentIndex++;
        ShowEntry(currentIndex);
    }

    public void ShowPreviousEntry()
    {
        if (entries.Count == 0 || currentIndex <= 0)
            return;

        currentIndex--;
        ShowEntry(currentIndex);
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
    }
}
