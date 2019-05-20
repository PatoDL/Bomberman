using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPF;
    GameObject floor;
    const int cantSpawnPositions =4;
    public GameObject pared;
    Vector3[] spawnPositions;
    public int cantEnemiesToSpawn=1;
    public int cantEnemies = 0;
    float timer = 0f;
    void Start()
    {
        floor = GameObject.Find("FloorController").transform.Find("Floor").gameObject;
        spawnPositions = new Vector3[cantSpawnPositions];
        spawnPositions[0] = new Vector3(pared.transform.localScale.x / 2 * 3, enemyPF.transform.localScale.y/2, pared.transform.localScale.x / 2 * 3);
        spawnPositions[1] = new Vector3(pared.transform.localScale.x / 2 * 3, enemyPF.transform.localScale.y / 2, floor.transform.localScale.x - pared.transform.localScale.z / 2);
        spawnPositions[2] = new Vector3(floor.transform.localScale.x - pared.transform.localScale.z / 2, enemyPF.transform.localScale.y / 2, floor.transform.localScale.x - pared.transform.localScale.z / 2);
        spawnPositions[3] = new Vector3(floor.transform.localScale.x - pared.transform.localScale.x / 2, enemyPF.transform.localScale.y / 2, pared.transform.localScale.x / 2 * 3);
        //EnemyBehaviour.OnEnemyKill = UpdateCantEnemies;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>5f && cantEnemiesToSpawn>0)
        {
            cantEnemiesToSpawn--;
            cantEnemies++;
            timer = 0f;
            GameObject e = Instantiate(enemyPF);
            e.gameObject.name = "Enemy";
            e.transform.position = spawnPositions[Random.Range(0, cantSpawnPositions)];
            e.GetComponent<EnemyBehaviour>().data.move = (PlayerController.Moves)Random.Range(0, 4);
        }

    }

    public void UpdateCantEnemies()
    {
        cantEnemies--;
    }
}
