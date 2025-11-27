using System.Runtime.InteropServices;
using UnityEngine;

public static class ClipBoardCopyWebGL
{
    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void CopyToClipboard(string str);
    #else
    private static void CopyToClipboard(string str) {
        Debug.Log("Clipboard copy simulated: " + str);
    }
    #endif

    public static void Copy(string text)
    {
        CopyToClipboard(text);
    }
}
