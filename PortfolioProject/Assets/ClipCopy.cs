using UnityEngine;

public class ClipCopy : MonoBehaviour
{
    [SerializeField] private string textToCopy = "Hello world!";

    // Call this from your Button OnClick()
    public void Copy()
    {
        ClipBoardCopyWebGL.Copy(textToCopy);
        Debug.Log("Copy triggered: " + textToCopy);
    }

    // Optional: set text dynamically
    public void SetText(string newText)
    {
        textToCopy = newText;
    }
}
