using UnityEngine;
using TMPro;
using System.Collections;

public class TMPGroupFader : MonoBehaviour
{
    [Header("Fade Settings")]
    [SerializeField] private TextMeshProUGUI[] texts; // assign all TMPs here
    [SerializeField] private float fadeDuration = 1f;

    private Coroutine fadeRoutine;

    /// <summary>
    /// Fade all assigned TextMeshProUGUI elements in (alpha 0 → 1)
    /// </summary>
    public void FadeGroupIn()
    {
        if (fadeRoutine != null)
            StopCoroutine(fadeRoutine);
        fadeRoutine = StartCoroutine(FadeGroup(0f, 1f));
    }

    /// <summary>
    /// Fade all assigned TextMeshProUGUI elements out (alpha 1 → 0)
    /// </summary>
    public void FadeGroupOut()
    {
        if (fadeRoutine != null)
            StopCoroutine(fadeRoutine);
        fadeRoutine = StartCoroutine(FadeGroup(1f, 0f));
    }

    private IEnumerator FadeGroup(float from, float to)
    {
        float t = 0f;

        // Set initial alpha for all texts
        foreach (var txt in texts)
        {
            if (txt == null) continue;
            Color c = txt.color;
            c.a = from;
            txt.color = c;
        }

        while (t < 1f)
        {
            t += Time.deltaTime / fadeDuration;
            float a = Mathf.Lerp(from, to, t);

            foreach (var txt in texts)
            {
                if (txt == null) continue;
                Color c = txt.color;
                c.a = a;
                txt.color = c;
            }

            yield return null;
        }

        // Set exact final alpha
        foreach (var txt in texts)
        {
            if (txt == null) continue;
            Color c = txt.color;
            c.a = to;
            txt.color = c;
        }
    }
}
