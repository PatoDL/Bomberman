using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int Score;
    bool finalDoor = false;
    int timer = 0;
    GameObject canvas;
    Text enemyCountText;
    PlayerController player;
    EnemySpawner eS;
    Text livesText;
    public bool gameOver = false;
    GameObject door;
    Vector3 PlayerStartPosition;

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

    void Start()
    {
       
    }

    void Init()
    {
        canvas = GameObject.Find("Canvas");
        enemyCountText = canvas.transform.Find("EnemyCountText").GetComponent<Text>();
        livesText = canvas.transform.Find("LivesText").GetComponent<Text>();
        eS = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        PlayerStartPosition = player.transform.position;
        player.lives = 2;
        eS.cantEnemies = 0;
        player.transform.position = PlayerStartPosition;
        gameOver = false;
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
                if (eS.cantEnemies <= 0)
                {
                    finalDoor = true;
                    OpenDoor();
                }
                if (player.hittedByBomb || player.hittedByEnemy)
                {
                    if (player.lives > 0)
                    {
                        player.lives--;
                        player.hittedByBomb = false;
                        player.hittedByEnemy = false;
                        player.transform.position = PlayerStartPosition;
                    }
                    else
                    {
                        gameOver = true;
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
            if(UIGameOverCanvas.playAgain && !changing)
            {
                UILoadingScreen.Instance.SetVisible(true);
                LoaderManager.Instance.LoadScene("Game");
                timer = 0;
                changing = true;
            }
        }
    }

    public void AddScore(int score)
    {
        Score += score;
    }

    public void ReInitPlayer()
    {

    }

    void OpenDoor()
    {

    }
}

