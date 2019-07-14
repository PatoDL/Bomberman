using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameCanvas : MonoBehaviour
{
    public Text enemyCountText;
    public Text livesText;
    public Text scoreText;
    public GameManager gm;
    public EnemySpawner es;
    public PlayerController pc;

    void Update()
    {
        enemyCountText.text = "Enemy count: " + es.GetCantEnemies();
        livesText.text = "Lives: " + pc.GetLives();
        scoreText.text = "Score: " + gm.GetScore();
    }

    
}