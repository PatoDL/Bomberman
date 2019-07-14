using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenuCanvas : MonoBehaviour
{
    void Start()
    {
        UILoadingScreen.Get().SetVisible(false);
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
