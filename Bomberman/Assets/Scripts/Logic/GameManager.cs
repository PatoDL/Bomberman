using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    int timer = 0;
    GameObject canvas;
    Text enemyCountText;
    PlayerController player;
    EnemySpawner eS;
    Text livesText;
    Text scoreText;
    public bool gameOver = false;
    DoorBehaviour door;

    public bool changing = false;

    private static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Init()
    {
        gameOver = false;
        canvas = GameObject.Find("Canvas");
        enemyCountText = canvas.transform.Find("EnemyCountText").GetComponent<Text>();
        livesText = canvas.transform.Find("LivesText").GetComponent<Text>();
        scoreText = canvas.transform.Find("ScoreText").GetComponent<Text>();
        eS = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        door = GameObject.Find("ExitDoor").GetComponent<DoorBehaviour>();
        player.lives = 2;
        eS.cantEnemies = 0;
        score = 0;
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            if (timer == 3)
                Init();

            if (timer >= 4)
            {
                enemyCountText.text = "Enemy count: " + eS.cantEnemies;
                livesText.text = "Lives: " + player.lives;
                scoreText.text = "Score: " + score;
                if(eS.addScore)
                {
                    score += eS.scoreToAdd;
                    eS.addScore = false;
                }
                if (eS.cantEnemies <=0 && eS.cantEnemies ==eS.cantEnemiesToSpawn)
                {
                    door.able = true;
                }
                if (player.hittedByBomb || player.hittedByEnemy)
                {
                    if (player.lives > 0)
                    {
                        player.lives--;
                        score -= 50;
                        if(score<0)
                        {
                            score = 0;
                        }
                        player.hittedByBomb = false;
                        player.hittedByEnemy = false;
                        player.transform.position = player.PlayerStartPosition;
                    }
                    else
                    {
                        gameOver = true;
                    }
                }
                if (door.exit)
                {
                    gameOver = true;
                }
                if(gameOver)
                {
                    if(PlayerPrefs.HasKey("HighScore"))
                    {
                        if(score>PlayerPrefs.GetInt("HighScore"))
                        {
                            PlayerPrefs.SetInt("HighScore", score);
                        }
                    }
                    else
                    {
                        PlayerPrefs.SetInt("HighScore", score);
                    }
                }
                if (gameOver && !changing)
                {
                    //if(!LoaderManager.Instance)
                    //{
                    //    LoaderManager.Create();
                    //}
                    UILoadingScreen.Instance.SetVisible(true);
                    LoaderManager.Instance.LoadScene("GameOver");
                    changing = true;
                }
            }
            timer++;
        }
        else if(SceneManager.GetActiveScene().name == "GameOver")
        {
            UIGameOverCanvas.highScore.text = PlayerPrefs.GetInt("HighScore").ToString();
            UIGameOverCanvas.score.text = score.ToString();
            if (UIGameOverCanvas.playAgain && !changing)
            {
                UIGameOverCanvas.playAgain = false;
                UILoadingScreen.Instance.SetVisible(true);
                LoaderManager.Instance.LoadScene("Game");
                timer = 0;
                changing = true;
            }
        }
    }
}