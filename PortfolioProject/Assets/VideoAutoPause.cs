using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class VideoAutoPause : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private RectTransform viewport;   // ScrollView Viewport
    [SerializeField] private RectTransform targetRect; // This video UI Rect
    [SerializeField] private GameObject resumeButton;

    private bool wasVisibleLastFrame = true;
    void Start()
    {
        viewport = FindAnyObjectByType<RectTransform>();
    }

    void Update()
    {
        if (videoPlayer == null || viewport == null || targetRect == null)
            return;

        bool isVisible = IsVisibleInViewport();

        // If it was visible and now it's not → pause
        if (!isVisible && wasVisibleLastFrame)
        {
            if (videoPlayer.isPlaying)
                videoPlayer.Pause();
                if(videoPlayer.isPrepared)
            {
                resumeButton.gameObject.SetActive(true);
                Debug.Log("displaying resume");
            }
                
        }

        wasVisibleLastFrame = isVisible;
    }
    public void buttonPause()
    {
        videoPlayer.Pause();
        resumeButton.gameObject.SetActive(true);
    }

    bool IsVisibleInViewport()
    {
        Vector3[] viewportCorners = new Vector3[4];
        Vector3[] targetCorners = new Vector3[4];

        viewport.GetWorldCorners(viewportCorners);
        targetRect.GetWorldCorners(targetCorners);

        Rect viewportRect = new Rect(
            viewportCorners[0],
            viewportCorners[2] - viewportCorners[0]
        );

        Rect targetRectWorld = new Rect(
            targetCorners[0],
            targetCorners[2] - targetCorners[0]
        );

        return viewportRect.Overlaps(targetRectWorld);
    }
}
