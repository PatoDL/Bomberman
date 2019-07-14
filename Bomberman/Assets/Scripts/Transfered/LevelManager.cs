using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviourSingleton<LevelManager>
{
    LevelData actualLevelData;

    int savedLevelThatComesFrom;

    void Start()
    {
        LevelData.PassLevelData = UpdateLevelData;
    }

    void UpdateLevelData(LevelData levelData)
    {
        actualLevelData = levelData;
    }

    public int GetActualLevel()
    {
        return actualLevelData.level;
    }

    public int GetLevelThatComesFrom()
    {
        return savedLevelThatComesFrom;
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
        savedLevelThatComesFrom = actualLevelData.level;
    }

    public void GoToNextLevel()
    {
        LoaderManager.Get().LoadScene(actualLevelData.nextLevel);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
