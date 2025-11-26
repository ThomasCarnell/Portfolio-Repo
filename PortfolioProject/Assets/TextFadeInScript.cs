// ...existing code...
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FadeMaterialDirect : MonoBehaviour
{
    [SerializeField] private Material targetMaterial;
    [SerializeField] private RawImage targetRawImage;
    [SerializeField] private Image targetImage;
    [SerializeField] private TextMeshProUGUI targetTextMesh;
    [SerializeField] private float fadeDuration = 1.5f;
    [SerializeField] private AnimationCurve fadeCurve = AnimationCurve.EaseInOut(0, 0, 1, 1); // curve for easing

    // material colors
    private Color matStartColor;
    private Color matEndColor;

    // rawimage colors
    private Color imgStartColor;
    private Color imgEndColor;

    private float timer;
    private bool fading;
    [SerializeField]
    private bool musingImage = false;
    void Start()
    {
        if (musingImage == true)
        {
            FadeIn();
        }
    }

    void OnEnable()
    {
        
    }

    void Update()
    {
        if (!fading) return;

        timer += Time.deltaTime;
        float t = Mathf.Clamp01(timer / fadeDuration);
        float curvedT = (fadeCurve != null) ? fadeCurve.Evaluate(t) : t;

        if (targetMaterial != null)
        {
            targetMaterial.color = Color.Lerp(matStartColor, matEndColor, curvedT);
        }

        if (targetRawImage != null)
        {
            targetRawImage.color = Color.Lerp(imgStartColor, imgEndColor, curvedT);
        }
        if( targetImage != null)
        {
            targetImage.color = Color.Lerp(imgStartColor, imgEndColor, curvedT);
        }
        if( targetTextMesh != null)
        {
            targetTextMesh.color = Color.Lerp(imgStartColor, imgEndColor, curvedT);
        }

        if (t >= 1f)
            fading = false;
    }

    public void FadeIn()
    {
        // prepare material
        if (targetMaterial != null)
        {
            matStartColor = targetMaterial.color;
            matEndColor = matStartColor;
            matEndColor.a = 1f;
        }

        // prepare raw image
        if (targetRawImage != null && musingImage == true)
        {
            imgStartColor = targetRawImage.color;
            imgEndColor = imgStartColor;
            imgEndColor.a = 1f;
        }

        // prepare image
        if (targetImage != null && musingImage == true)
        {
            imgStartColor = targetImage.color;
            imgEndColor = imgStartColor;
            imgEndColor.a = 1f;
        }
        // prepare textmesh
        if (targetTextMesh != null && musingImage == true)
        {
            imgStartColor = targetTextMesh.color;
            imgEndColor = imgStartColor;
            imgEndColor.a = 1f;
        }

        timer = 0f;
        fading = true;
    }

    public void FadeOut()
    {
        // prepare material
        if (targetMaterial != null)
        {
            matStartColor = targetMaterial.color;
            matEndColor = matStartColor;
            matEndColor.a = 0f;
        }

        // prepare raw image
        if (targetRawImage != null)
        {
            imgStartColor = targetRawImage.color;
            imgEndColor = imgStartColor;
            imgEndColor.a = 0f;
        }

        timer = 0f;
        fading = true;
    }

    private void ResetAlpha()
    {
        if (targetMaterial != null)
        {
            Color c = targetMaterial.color;
            c.a = 1f; // fully opaque
            targetMaterial.color = c;
        }

        if (targetRawImage != null)
        {
            Color c = targetRawImage.color;
            c.a = 1f; // fully opaque
            targetRawImage.color = c;
        }
    }
}
// ...existing code...