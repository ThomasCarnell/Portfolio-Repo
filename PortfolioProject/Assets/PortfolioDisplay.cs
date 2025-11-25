using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;

public class PortfolioDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text dateText;
    [SerializeField] private TMP_Text roleText;
    [SerializeField] private TMP_Text descriptionText;
    //[SerializeField] private string webLink;
    [Header("Video Media")]
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private RawImage videoDisplay;
        private string videoURL;

    //[SerializeField] private Image thumbnailImage;

    private PortfolioEntry currentEntry;

    public void SetEntry(PortfolioEntry entry)
    {
        currentEntry = entry;
        titleText.text = entry.projectName;
        dateText.text = entry.productionDate;
        roleText.text = entry.roles;
        descriptionText.text = entry.description;
        //webLink.text = entry.webLink;

            if (!string.IsNullOrEmpty(entry.videoURL))
        {
            videoURL = entry.videoURL;
            SetupVideo(videoURL);
        }

        // Video
        // if (entry.showcaseVideo != null)
        // {
        //     VideoPlayer.clip = entry.showcaseVideo;

        //     // Bind output texture
        //     if (videoDisplay != null)
        //     {
        //         VideoPlayer.renderMode = VideoRenderMode.RenderTexture;
        //         videoDisplay.texture = VideoPlayer.targetTexture;
        //     }

        //     VideoPlayer.Stop();
        //     VideoPlayer.Play();
        // }
        // else
        // {
        //     // If no video, ensure player is off
        //     if (VideoPlayer) VideoPlayer.Stop();
        // }

    }
        private void SetupVideo(string url)
    {
        if (videoPlayer == null) return;

        videoPlayer.source = VideoSource.Url;
        videoPlayer.url = url;
        videoPlayer.Prepare();
        videoPlayer.prepareCompleted += OnVideoPrepared;
    }

    private void OnVideoPrepared(VideoPlayer vp)
    {
        vp.Play();

             // Resize RawImage to match RenderTexture size
        float aspect = (float)vp.texture.width / vp.texture.height;
        RectTransform rt = videoDisplay.rectTransform;
        rt.sizeDelta = new Vector2(rt.sizeDelta.y * aspect, rt.sizeDelta.y);
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
