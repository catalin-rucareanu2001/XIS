using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Button : MonoBehaviour
{

    public void OnQuitButtonClick()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
