using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public delegate void OnEnemyKill();
    public static OnEnemyKill KillEnemy;

    public enum State
    {
        idle
    }

    public EnemyData data;
    public bool pacmanmode = false;

    public bool ignorePathFinder = false;
    float ignoreTimer = 0f;
    public int prefX;
    public int prefZ;
    public bool[] lockedWays;
    public GameObject player;
    public int m;

    void Start()
    {
        m = Random.Range(0, (int)PlayerController.Moves.last);
        player = GameObject.Find("Player");
        
        lockedWays = new bool[(int)PlayerController.Moves.last];
        for (int i = 0; i < (int)PlayerController.Moves.last; i++)
            lockedWays[i] = false;
    }

    void Update()
    {
        if(ignorePathFinder)
        {
            IgnorePathFinder(3f);
        }
        else
            ChangePath();
        data.move = (PlayerController.Moves)m;
        Move();
    }

    void IgnorePathFinder(float ignoreDuration)
    {
        ignoreTimer += Time.deltaTime;
        if (ignoreTimer > ignoreDuration)
        {
            ignorePathFinder = false;
            ignoreTimer = 0f;
        }
    }

    public void InverseMovement()
    {
        switch (m)
        {
        case (int)PlayerController.Moves.up:
            m = (int)PlayerController.Moves.down;
            break;
        case (int)PlayerController.Moves.down:
            m = (int)PlayerController.Moves.up;
            break;
        case (int)PlayerController.Moves.right:
            m = (int)PlayerController.Moves.left;
            break;
        case (int)PlayerController.Moves.left:
            m = (int)PlayerController.Moves.right;
            break;
        }
    }

    void Move()
    {
        if (data.state == State.idle)
        {
            data.direction = DirectionSelector(data.move);
            transform.position += data.direction * data.speed * Time.deltaTime;
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

    void CheckLives()
    {
        data.lives--;
        if (data.lives <= 0)
        {
            KillEnemy();
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Bomb")
        {
            InverseMovement();
            ignorePathFinder = true;
        }
        else if(col.gameObject.name == "Player" && pacmanmode)
        {
            CheckLives();
        }
        transform.rotation = Quaternion.identity;
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Explosion")
        {
            CheckLives();
        }
    }

    void ChangePath()
    {
        bool hasToChangePath = lockedWays[m];
        if (!lockedWays[SetPreferencedPath()])
        {
            m = SetPreferencedPath();
        }
        else if (hasToChangePath)
        {
            m = CheckForUnlockedPaths((PlayerController.Moves)m);
        }

        if (pacmanmode)
            InverseMovement();
    }

    int CheckForUnlockedPaths(PlayerController.Moves mLocked)
    {
        int path = (int)mLocked;
        for (int i = 0; i < (int)PlayerController.Moves.last; i++)
        {
            if (!lockedWays[i])
            {
                path = i;
            }
        }
        return path;
    }

    int SetPreferencedPath()
    {
        Transform en = transform;
        Transform p = player.transform;
        int chosenPref;

        if (Mathf.Abs((int)(p.position.x - en.position.x)) > Mathf.Abs((int)(p.position.z - en.position.z)))
            chosenPref = prefX;
        else if (Mathf.Abs((int)(p.position.x - en.position.x)) < Mathf.Abs((int)(p.position.z - en.position.z)))
            chosenPref = prefZ;
        else
            chosenPref = prefZ;

        if (lockedWays[prefX])
            chosenPref = prefZ;
        else if (lockedWays[prefZ])
            chosenPref = prefX;

        return chosenPref;
    }
}
