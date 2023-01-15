using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quit : MonoBehaviour
{
#if UNITY_STANDALONE
    [SerializeField] private TMP_Text exitButtonText;
#endif

    void Awake()
    {
#if UNITY_EDITOR || UNITY_WEBGL
        gameObject.SetActive(false);
#endif
#if UNITY_ANDROID
        exitButtonText.text = "Quit to Android";
#elif UNITY_IOS
        exitButtonText.text = "Quit to iOS";
#elif UNITY_STANDALONE_WIN
        exitButtonText.text = "Quit to Windows";
#elif UNITY_STANDALONE_OSX
        exitButtonText.text = "Quit to macOS";
#elif UNITY_STANDALONE_LINUX
        exitButtonText.text = "Quit to Linux";
#endif
    }

#if UNITY_STANDALONE
    public void QuitToOS() => Application.Quit();
#endif
}