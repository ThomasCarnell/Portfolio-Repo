using UnityEngine;
using System.Collections.Generic;

public class PortfolioManagerScroll : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Transform uiParent;        // Content object
    [SerializeField] private GameObject entryUIPrefab;

    private List<GameObject> spawnedEntries = new();

    [Header("Categories")]
    [SerializeField] private List<PortfolioEntry> entries_unity;
    [SerializeField] private List<PortfolioEntry> entries_soundDesign;
    [SerializeField] private List<PortfolioEntry> entries_physical;

    void Start()
    {
        // Optional default category
        ShowUnityPortfolio();
    }

    // ---------- Category Buttons ----------

    public void ShowUnityPortfolio()
    {
        ShowEntries(entries_unity);
    }

    public void ShowSoundDesignPortfolio()
    {
        ShowEntries(entries_soundDesign);
    }

    public void ShowPhysicalPortfolio()
    {
        ShowEntries(entries_physical);
    }

    // ---------- Core ----------

    public void ShowEntries(List<PortfolioEntry> entrySet)
    {
        ClearPortfolio();

        if (entrySet == null || entrySet.Count == 0)
        {
            Debug.LogWarning("No entries to display.");
            return;
        }

        foreach (var entry in entrySet)
        {
            GameObject ui = Instantiate(entryUIPrefab, uiParent);

            var display = ui.GetComponent<PortfolioDisplay>();
            if (display != null)
                display.SetEntry(entry);

            spawnedEntries.Add(ui);
        }

        Debug.Log($"Displayed {entrySet.Count} entries.");
    }

    private void ClearPortfolio()
    {
        foreach (var obj in spawnedEntries)
            if (obj != null)
                Destroy(obj);

        spawnedEntries.Clear();
    }
}
