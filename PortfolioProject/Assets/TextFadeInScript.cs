using UnityEngine;

public class FadeMaterialDirect : MonoBehaviour
{
    [SerializeField] private Material targetMaterial;
    [SerializeField] private float fadeDuration = 1.5f;

    private Color startColor;
    private Color endColor;
    private float timer;
    private bool fading;

    void Start()
    {
        ResetAlpha();
    }

    void OnEnable()
    {
        if (targetMaterial == null) return;
        ResetAlpha();
    }

    void Update()
    {
        if (!fading || targetMaterial == null) return;

        timer += Time.deltaTime;
        float t = Mathf.Clamp01(timer / fadeDuration);

        Color c = Color.Lerp(startColor, endColor, t);
        targetMaterial.color = c;

        if (t >= 1f)
            fading = false;
    }

    public void FadeIn()
    {
        if (targetMaterial == null) return;

        // Always fade from current alpha to fully opaque
        startColor = targetMaterial.color;
        endColor = startColor;
        endColor.a = 1f;

        timer = 0f;
        fading = true;
    }

    public void FadeOut()
    {
        if (targetMaterial == null) return;

        // Always fade from current alpha to fully transparent
        startColor = targetMaterial.color;
        endColor = startColor;
        endColor.a = 0f;

        timer = 0f;
        fading = true;
    }

    private void ResetAlpha()
    {
        if (targetMaterial == null) return;

        Color c = targetMaterial.color;
        c.a = 1f; // fully opaque
        targetMaterial.color = c;
    }
}
