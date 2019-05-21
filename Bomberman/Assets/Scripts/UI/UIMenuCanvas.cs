using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIMenuCanvas : MonoBehaviour
{
    GameObject canvas;
    Button PlayButton;
    Button QuitButton;
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        PlayButton = canvas.transform.Find("Panel").Find("PlayButton").GetComponent<Button>();
        QuitButton = canvas.transform.Find("Panel").Find("QuitButton").GetComponent<Button>();
        PlayButton.onClick.AddListener(PlayGame);
        QuitButton.onClick.AddListener(Quit);

        UILoadingScreen.Instance.SetVisible(false);
    }

    void Update()
    {
        
    }

    public void PlayGame()
    {
        LoaderManager.Instance.LoadScene("Game");
        UILoadingScreen.Instance.SetVisible(true);
    }

    public static void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
