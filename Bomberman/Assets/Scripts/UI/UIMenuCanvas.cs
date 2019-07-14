using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIMenuCanvas : MonoBehaviour
{
    void Start()
    {
        UILoadingScreen.Get().SetVisible(false);
    }

    void Update()
    {
        
    }

    public void PlayGame()
    {
        LevelManager.Get().GoToNextLevel();
        
    }

    public void Quit()
    {
        LevelManager.Get().QuitGame();
    }
}
