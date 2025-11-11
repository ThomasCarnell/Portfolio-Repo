using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;

public class PortfolioDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text dateText;
    [SerializeField] private TMP_Text descriptionText;
    [SerializeField] private VideoClip showcaseVideo;
    //[SerializeField] private Image thumbnailImage;

    private PortfolioEntry currentEntry;

    public void SetEntry(PortfolioEntry entry)
    {
        currentEntry = entry;
        titleText.text = entry.projectName;
        dateText.text = entry.productionDate;
        descriptionText.text = entry.description;
        showcaseVideo = entry.showcaseVideo;
    }

    public void OpenWebLink()
    {
        if (!string.IsNullOrEmpty(currentEntry.webLink))
            Application.OpenURL(currentEntry.webLink);
    }
}
