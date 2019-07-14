using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    public int score;
    public bool gameOver = false;

    void Start()
    {
        EnemyBehaviour.KillEnemy += AddScore;
        PlayerController.PlayerHit += RemoveScore;
        gameOver = false;
        score = 0;
    }

    void OnDestroy()
    {
        PlayerController.PlayerHit -= RemoveScore;
        EnemyBehaviour.KillEnemy -= AddScore;
    }

    public int GetScore()
    {
        return score;
    }

    void AddScore()
    {
        score += 50;
    }

    void RemoveScore()
    {
        score -= 50;
        if (score < 0)
        {
            score = 0;
        }
    }

    void Update()
    {

        if (gameOver)
        {
            if (PlayerPrefs.HasKey("HighScore"))
            {
                if (score > PlayerPrefs.GetInt("HighScore"))
                {
                    PlayerPrefs.SetInt("HighScore", score);
                }
            }
            else
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
        }

    }
}