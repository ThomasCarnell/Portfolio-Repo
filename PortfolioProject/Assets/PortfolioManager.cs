using UnityEngine;
using System.Collections.Generic;

public class PortfolioManager : MonoBehaviour
{
    [Header("Portfolio Setup")]
    [SerializeField] private List<PortfolioEntry> entries = new();
    [SerializeField] private Transform uiParent;
    [SerializeField] private GameObject entryUIPrefab;

    private List<GameObject> spawnedEntries = new();

    // 🔹 Optional: you can have multiple entry sets (categories)
    [Header("Optional Categories")]
    [SerializeField] private List<PortfolioEntry> demoEntries;
    [SerializeField] private List<PortfolioEntry> designEntries;
    [SerializeField] private List<PortfolioEntry> codeEntries;

    void Start()
    {
        Debug.Log($"📁 PortfolioManager ready — entries: {entries.Count}");
    }

    // 🔹 Called by your custom button system
    public void ShowEntries(List<PortfolioEntry> entrySet)
    {
        if (entrySet == null || entrySet.Count == 0)
        {
            Debug.LogWarning("⚠️ No entries found for this category.");
            return;
        }

        ClearPortfolio();
        PopulatePortfolio(entrySet);
    }

    // 🔹 For example, hook these to your custom button events
    public void ShowDemoEntries() => ShowEntries(demoEntries);
    public void ShowDesignEntries() => ShowEntries(designEntries);
    public void ShowCodeEntries() => ShowEntries(codeEntries);

    // --- internal helpers ---

    private void PopulatePortfolio(List<PortfolioEntry> entrySet)
    {
        foreach (var entry in entrySet)
        {
            if (entryUIPrefab == null || uiParent == null)
            {
                Debug.LogError("❌ Missing UI Prefab or UI Parent reference.");
                return;
            }

            GameObject ui = Instantiate(entryUIPrefab, uiParent);
            var display = ui.GetComponent<PortfolioDisplay>();

            if (display != null)
            {
                display.SetEntry(entry);
                Debug.Log($"✅ Spawned entry: {entry.projectName}");
            }
            else
            {
                Debug.LogWarning("⚠️ Missing PortfolioDisplay component on prefab.");
            }

            spawnedEntries.Add(ui);
        }
    }

    public void ClearPortfolio()
    {
        Debug.Log($"🧹 Clearing {spawnedEntries.Count} spawned entries...");

        foreach (var e in spawnedEntries)
        {
            if (e != null)
                Destroy(e);
        }

        spawnedEntries.Clear();
    }
}
