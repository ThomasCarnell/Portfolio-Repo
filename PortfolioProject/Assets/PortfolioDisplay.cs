using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;

public class PortfolioDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text dateText;
    [SerializeField] private TMP_Text descriptionText;
    [Header("Video Media")]
    [SerializeField] private VideoPlayer VideoPlayer;
    [SerializeField] private RawImage videoDisplay;
    //[SerializeField] private Image thumbnailImage;

    private PortfolioEntry currentEntry;

    public void SetEntry(PortfolioEntry entry)
    {
        currentEntry = entry;
        titleText.text = entry.projectName;
        dateText.text = entry.productionDate;
        descriptionText.text = entry.description;

        // Video
        if (entry.showcaseVideo != null)
        {
            VideoPlayer.clip = entry.showcaseVideo;

            // Bind output texture
            if (videoDisplay != null)
            {
                VideoPlayer.renderMode = VideoRenderMode.RenderTexture;
                videoDisplay.texture = VideoPlayer.targetTexture;
            }

            VideoPlayer.Stop();
            VideoPlayer.Play();
        }
        else
        {
            // If no video, ensure player is off
            if (VideoPlayer) VideoPlayer.Stop();
        }

    }

    void OnEnable()
    {
        GetComponentInChildren<TMPGroupFader>().FadeGroupIn();
    }
    void OnDisable()
    {
        GetComponentInChildren<TMPGroupFader>().FadeGroupOut();
    }

    public void OpenWebLink()
    {
        if (!string.IsNullOrEmpty(currentEntry.webLink))
            Application.OpenURL(currentEntry.webLink);
    }
}
