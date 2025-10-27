using UnityEngine;
using TMPro;

public class ButtonLabelTracker : MonoBehaviour
{
    public TextMeshProUGUI label;  // The UI label
    public Vector3 offset = new Vector3(0, 1f, 0);  // Slightly above the button
    private Camera cam;
    private Canvas canvas;

    void Start()
    {
        cam = Camera.main;
        canvas = label.canvas; // get the label’s canvas
    }

    void Update()
    {
        if (!label || !cam || !canvas) return;

        // World → Screen position
        Vector3 screenPos = cam.WorldToScreenPoint(transform.position + offset);

        // Skip if behind the camera
        if (screenPos.z < 0)
        {
            label.enabled = false;
            return;
        }

        label.enabled = true;

        // Convert screen position to canvas-space position
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            screenPos,
            cam,
            out Vector2 localPos
        );

        // Apply to label
        label.rectTransform.anchoredPosition = localPos;
    }
}
