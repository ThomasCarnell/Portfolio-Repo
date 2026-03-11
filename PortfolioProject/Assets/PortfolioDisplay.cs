using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;
using System;

public class PortfolioDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text dateText;
    [SerializeField] private TMP_Text roleText;
    [SerializeField] private TMP_Text descriptionText;
    [SerializeField] private TMP_Text addText;
    [SerializeField] private TMP_Text addText2;
    [SerializeField] private TMP_Text webLink;
    [SerializeField] private GameObject copyButton;
    [Header("Video Media")]
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private RawImage videoDisplay;
    [SerializeField] private Button playVideoButton;
    private string videoURL;
    private bool videoClicked = false;
    private bool isPrepared = false;
  
    [SerializeField] private GameObject playOverlay;

    private PortfolioEntry currentEntry;

    public void SetEntry(PortfolioEntry entry)
    {
        currentEntry = entry;
        titleText.text = entry.projectName;
        dateText.text = entry.productionDate;
        roleText.text = entry.roles;
        descriptionText.text = entry.description;
        webLink.text = entry.webLink;
        addText.text = entry.addText;
        addText2.text = entry.addText2;

        if(webLink.text == "Carcompose@gmail.com")
        {
            copyButton.SetActive(true);
        }
        else
        {
            copyButton.SetActive(false);
        }

            if (!string.IsNullOrEmpty(entry.videoURL))
        {
            videoURL = entry.videoURL;
            playVideoButton.gameObject.SetActive(true);
        }
    }
    
        private void SetupVideo(string url)
    {
        if (videoPlayer == null) return;
        videoPlayer.source = VideoSource.Url;
        videoPlayer.url = url;
        videoPlayer.Prepare();
        videoPlayer.prepareCompleted += OnVideoPrepared;

            // Start checking for video end
            if (isPrepared && videoPlayer.frame >= (long)videoPlayer.frameCount - 1)
        {
            videoPlayer.frame = 0;
            videoPlayer.Play();
            if (playOverlay != null) playOverlay.SetActive(false);
            return;
        }
    }
    

    public void OnVideoPrepared(VideoPlayer vp)
    {
        vp.Play();
        // Resize RawImage to match RenderTexture size
        float aspect = (float)vp.texture.width / vp.texture.height;
        RectTransform rt = videoDisplay.rectTransform;
        rt.sizeDelta = new Vector2(rt.sizeDelta.y * aspect, rt.sizeDelta.y);
        videoClicked = true;
    }
    public void PlayVideoNow()
    {
      SetupVideo(videoURL);
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
