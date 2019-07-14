using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPF;

    const int cantSpawnPositions = 4;
    Vector3[] spawnPositions;
    public int cantEnemiesToSpawn=1;
    public int cantEnemies = 0;
    float timer = 0f;

    List<GameObject> enemies = new List<GameObject>();

    public static bool pacmanmode = false;
    float pacmanmodeTimer = 0f;
    public float pacmanmodeTimeLimit;

    public float startPositionxz;

    public delegate void OnDoorActivation();
    public static OnDoorActivation ActivateDoor;

    void Start()
    {
        Physics.IgnoreLayerCollision(8, 8);
        Physics.IgnoreLayerCollision(8, 13);
        Physics.IgnoreLayerCollision(8, 14);
        cantEnemies = 0;
        EnemyBehaviour.KillEnemy += UpdateCantEnemies;
        ItemBehaviour.ActivatePacmanMode = ActivatePacmanMode;
        StartSpawnPos();       
    }

    void OnDestroy()
    {
        EnemyBehaviour.KillEnemy -= UpdateCantEnemies;
    }

    void StartSpawnPos()
    {
        spawnPositions = new Vector3[cantSpawnPositions];
        spawnPositions[0] = new Vector3(-startPositionxz, 1.3f, -startPositionxz);
        spawnPositions[1] = new Vector3(-startPositionxz, 1.3f, startPositionxz);
        spawnPositions[2] = new Vector3(startPositionxz, 1.3f, startPositionxz);
        spawnPositions[3] = new Vector3(startPositionxz, 1.3f, -startPositionxz);
    }

    void Update()
    {
        timer += Time.deltaTime;
        bool spawnNewEnemy = timer > 5f && cantEnemiesToSpawn > 0;
        if (spawnNewEnemy)
        {
            cantEnemiesToSpawn--;
            cantEnemies++;
            timer = 0f;
            GameObject e = Instantiate(enemyPF);
            e.gameObject.name = "Enemy";
            e.transform.position = spawnPositions[Random.Range(0, cantSpawnPositions)];
            enemies.Add(e);
        }
        if(pacmanmode)
        {
            pacmanmodeTimer += Time.deltaTime;
            if(pacmanmodeTimer>pacmanmodeTimeLimit)
            {
                pacmanmode = false;
                pacmanmodeTimer = 0f;
                for(int i=0;i<enemies.Count;i++)
                {
                    if (enemies[i])
                    {
                        enemies[i].GetComponent<EnemyBehaviour>().pacmanmode = false;
                        enemies[i].GetComponent<MeshRenderer>().material.color = Color.white;
                    }
                    else
                    {
                        enemies.RemoveAt(i);
                        i--;
                    }
                }
            }
        }
    }

    public int GetCantEnemies()
    {
        return cantEnemies;
    }

    public void UpdateCantEnemies()
    {
        cantEnemies--;
        bool noMoreEnemies = cantEnemies <= 0 && cantEnemies == cantEnemiesToSpawn;
        if (noMoreEnemies)
        {
            ActivateDoor();
        }
    }

    void ActivatePacmanMode()
    {
        pacmanmode = true;
        pacmanmodeTimer = 0f;
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i])
            {
                enemies[i].GetComponent<EnemyBehaviour>().pacmanmode = true;
                enemies[i].GetComponent<MeshRenderer>().material.color = Color.red;
            }
            else
            {
                enemies.RemoveAt(i);
                i--;
            }
        }
    }
}
