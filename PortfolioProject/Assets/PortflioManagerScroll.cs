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
    [SerializeField] private List<PortfolioEntry> entries_vr;
    [SerializeField] private List<PortfolioEntry> entries_about;

    void Start()
    {
        // Optional default category
        ShowAboutPortfolio();
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
    public void ShowVRPortfolio()
    {
        ShowEntries(entries_vr);
    }
    public void ShowAboutPortfolio()
    {
        ShowEntries(entries_about);
    }

    // ---------- Core ----------

    public void ShowEntries(List<PortfolioEntry> entrySet)
    {
        ClearPortfolioScroll();

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

    public void ClearPortfolioScroll()
    {
        foreach (var obj in spawnedEntries)
            if (obj != null)
                Destroy(obj);

        spawnedEntries.Clear();
    }
}
