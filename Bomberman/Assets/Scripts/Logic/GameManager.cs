using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DVJ02.Clase03
{
    public class GameManager : MonoBehaviour
    {
        public int Score;
        bool finalDoor = false;

        public Text enemyCountText;
        PlayerController player;
        public EnemySpawner eS;
        public Text livesText;

        private static GameManager instance;
        public static GameManager Get()
        {
            return instance;
        }

        private void Awake()
        {
            if (!instance)
            {
                instance = this;
            }
            else
            {
                Destroy(instance);
            }
            DontDestroyOnLoad(this);
        }

        void Start()
        {
            eS = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
            player = GameObject.Find("Player").GetComponent<PlayerController>();
        }

        void Update()
        {
            enemyCountText.text = "Enemy count: " + eS.cantEnemies;
            livesText.text = "Lives: " + player.lives;
        }

        public void AddScore(int score)
        {
            Score += score;
        }
    }
}
