using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameOverCanvas : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;

    void Start()
    {
        scoreText.text = "Your Score is: " + GameManager.Get().GetScore().ToString();
        highScoreText.text = "Your HighScore is: " + PlayerPrefs.GetInt("HighScore").ToString();
    }

    public void PlayAgain()
    {
        LevelManager.Get().GoToNextLevel();
    }

    public void Quit()
    {
        LevelManager.Get().QuitGame();
    }
}
