using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoRenderTextureSetup : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private RawImage rawImage;

    private RenderTexture renderTexture;

    void Awake()
    {
        CreateRenderTexture();
    }

    void CreateRenderTexture()
    {
        // Create unique RenderTexture for this entry
        renderTexture = new RenderTexture(1280, 720, 0, RenderTextureFormat.ARGB32);
        renderTexture.Create();

        // Assign to VideoPlayer and RawImage
        videoPlayer.targetTexture = renderTexture;
        rawImage.texture = renderTexture;
    }

    void OnDestroy()
    {
        if (renderTexture != null)
        {
            renderTexture.Release();
            Destroy(renderTexture);
        }
    }
}
