using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "NewPortfolioEntry", menuName = "Portfolio/Entry")]
public class PortfolioEntry : ScriptableObject
{
    [Header("Basic Info")]
    public string projectName;
    [TextArea(10, 20)] public string description;
    [TextArea(5, 10)] public string addText;
    [TextArea(5, 10)] public string addText2;
    public string roles;
    public string productionDate;

    [Header("Media")]
    public Sprite thumbnail;
    public string webLink; // Optional: link to demo, GitHub, etc.
    public VideoClip showcaseVideo; // If you have a short video
    public GameObject projectPrefab; // Optional 3D model to display
    public string videoURL; // Optional: link to external video
    [SerializeField]
    public Image picture;
    [Header("Tags / Metadata")]
    public string[] tags; // e.g. ["Unity", "C#", "Shader Graph"]
}
