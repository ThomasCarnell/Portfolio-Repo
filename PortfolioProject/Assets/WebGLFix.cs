using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class WebGLVideoFix : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer videoPlayer;

    void Start()
    {
        // Hide black box
        rawImage.enabled = false;

        // Show when video is ready to play
        videoPlayer.prepareCompleted += OnVideoPrepared;
        videoPlayer.Prepare();
    }

    void OnVideoPrepared(VideoPlayer vp)
    {
        rawImage.texture = videoPlayer.texture;
        rawImage.enabled = true;
    }
}
