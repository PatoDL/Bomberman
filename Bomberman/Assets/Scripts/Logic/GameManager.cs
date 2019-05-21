using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    bool gameOver = false;
    GameObject door;
    Vector3 PlayerStartPosition;

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
    }

    void Update()
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
        }
        timer++;
    }

    public void AddScore(int score)
    {
        Score += score;
    }

    void OpenDoor()
    {

    }
}

