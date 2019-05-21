using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UICanvas : MonoBehaviour
{
    GameObject canvas;
    Button PlayButton;
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        PlayButton = canvas.transform.Find("Panel").Find("PlayButton").GetComponent<Button>();
        PlayButton.onClick.AddListener(PlayGame);

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
}
