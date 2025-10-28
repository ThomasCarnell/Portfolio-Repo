using UnityEngine;

public class FadeMaterialDirect : MonoBehaviour
{
    [SerializeField] private Material targetMaterial;
    [SerializeField] private float fadeDuration = 1.5f;

    private Color startColor;
    private Color endColor;
    private float timer;
    private bool fading;

    void OnEnable()
    {
        if (targetMaterial == null) return;

        endColor = targetMaterial.color;
        startColor = endColor;
        startColor.a = 0f;
        targetMaterial.color = startColor;

        timer = 0f;
        fading = true;
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
}
