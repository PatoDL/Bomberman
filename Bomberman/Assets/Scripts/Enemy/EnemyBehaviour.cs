using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    //public delegate void EnemyKilled();
    //public static EnemyKilled OnEnemyKill; 
    public enum State
    {
        idle, chase
    }

    public EnemyData data;
    public GameObject explosionPF;

    public int wallCollisionX = 0;
    public int wallCollisionZ = 0;
    public int m;

    EnemySpawner eS;

    void Start()
    {
        m = Random.Range(0, 3);
        eS = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if(data.lives<=0)
        {
            eS.UpdateCantEnemies();
            Destroy(this.gameObject);
        }
        data.move = (PlayerController.Moves)m;
        move();
    }

    void move()
    {
        if (data.state == State.idle)
        {
            data.direction = DirectionSelector(data.move);
            transform.position += data.direction * data.speed * Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name=="Explosion")
        {
            data.lives--;
        }
    }

    Vector3 DirectionSelector(PlayerController.Moves m)
    {
        switch (m)
        {
            case PlayerController.Moves.up:
                return new Vector3(0, 0, 1);
            case PlayerController.Moves.down:
                return new Vector3(0, 0, -1);
            case PlayerController.Moves.left:
                return new Vector3(-1, 0, 0);
            case PlayerController.Moves.right:
                return new Vector3(1, 0, 0);
            default:
                return new Vector3(0, 0, 1);
        }
    }
}
