using UnityEngine;

public class ButtonResetAnimation : MonoBehaviour
{
    public enum EaseType { Linear, EaseIn, EaseOut, EaseInOut, SmoothStep, Exponential, Elastic, Bounce }

    [SerializeField] private Vector3 targetScale = Vector3.one;
    [SerializeField] private float duration = 1f;
    [SerializeField] private EaseType easeType = EaseType.SmoothStep;

    private Vector3 originalScale;
    private float timer;
    private bool scaling = false;
    private bool reverse = false;

    [SerializeField]
    private GameManager GameManager;

    void Awake()
    {
        // Save the original (default) scale at startup
        originalScale = transform.localScale;
        GameManager = Object.FindAnyObjectByType<GameManager>();
    }

    void OnEnable()
    {
        StartScaling();
    }

    void OnDisable()
    {
        // Reset so that next enable plays cleanly
        scaling = false;
        reverse = false;
        timer = 0f;
        transform.localScale = originalScale; // Restore starting scale
    }

    public void StartScaling()
    {
        timer = 0f;
        scaling = true;
        reverse = false;
    }

    public void StartReverseScaling()
    {
        timer = 0f;
        scaling = true;
        reverse = true;
    }

    void Update()
    {
        if (!scaling) return;

        timer += Time.deltaTime;
        float t = Mathf.Clamp01(timer / duration);
        t = ApplyEase(t, easeType);

        // Forward animation: from original → target
        // Reverse animation: from target → original
        if (reverse)
            transform.localScale = Vector3.Lerp(targetScale, originalScale, t);
        else
            transform.localScale = Vector3.Lerp(originalScale, targetScale, t);

        if (t >= 1f)
            scaling = false;
    }

    private float ApplyEase(float t, EaseType type)
    {
        switch (type)
        {
            default:
            case EaseType.Linear: return t;
            case EaseType.EaseIn: return t * t;
            case EaseType.EaseOut: return 1 - Mathf.Pow(1 - t, 2);
            case EaseType.EaseInOut: return t * t * (3 - 2 * t);
            case EaseType.SmoothStep: return Mathf.SmoothStep(0, 1, t);
            case EaseType.Exponential: return Mathf.Pow(2, 10 * (t - 1));
            case EaseType.Elastic: return Mathf.Sin(-13f * (t + 1) * Mathf.PI / 2f) * Mathf.Pow(2f, -10f * t) + 1f;
            case EaseType.Bounce: return Bounce(t);
        }
    }

    private float Bounce(float t)
    {
        if (t < 4 / 11.0f)
            return (121 * t * t) / 16.0f;
        else if (t < 8 / 11.0f)
            return (363 / 40.0f * t * t) - (99 / 10.0f * t) + 17 / 5.0f;
        else if (t < 9 / 10.0f)
            return (4356 / 361.0f * t * t) - (35442 / 1805.0f * t) + 16061 / 1805.0f;
        else
            return (54 / 5.0f * t * t) - (513 / 25.0f * t) + 268 / 25.0f;
    }
}
