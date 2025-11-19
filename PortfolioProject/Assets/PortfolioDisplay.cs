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
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private RawImage videoDisplay;
    //[SerializeField] private Image thumbnailImage;

    private PortfolioEntry currentEntry;

    public void SetEntry(PortfolioEntry entry)
    {
        currentEntry = entry;
        titleText.text = entry.projectName;
        dateText.text = entry.productionDate;
        descriptionText.text = entry.description;

           if (!string.IsNullOrEmpty(entry.videoFileURL))
            LoadVideo(entry.videoFileURL);

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
    private void LoadVideo(string url)
    {
        string path = System.IO.Path.Combine(Application.streamingAssetsPath, url);

        Debug.Log("🎥 Loading video from: " + path);

        videoPlayer.source = VideoSource.Url;
        videoPlayer.url = url;

        videoPlayer.Prepare();
     videoPlayer.prepareCompleted += (vp) => vp.Play();   
      }

    private void OnVideoPrepared(VideoPlayer vp)
    {
        vp.prepareCompleted -= OnVideoPrepared;

        Debug.Log("✅ Video prepared, playing...");
        vp.Play();
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
