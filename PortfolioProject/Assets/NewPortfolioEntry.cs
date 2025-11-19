using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "NewPortfolioEntry", menuName = "Portfolio/Entry")]
public class PortfolioEntry : ScriptableObject
{
    [Header("Basic Info")]
    public string projectName;
    [TextArea] public string description;
    public string[] roles;
    public string productionDate;

    [Header("Media")]
    public Sprite thumbnail;
    public string webLink; // Optional: link to demo, GitHub, etc.
    public VideoClip showcaseVideo; // If you have a short video

    public string videoFileURL;
    public GameObject projectPrefab; // Optional 3D model to display

    [Header("Tags / Metadata")]
    public string[] tags; // e.g. ["Unity", "C#", "Shader Graph"]
}
