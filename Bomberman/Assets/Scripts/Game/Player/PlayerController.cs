using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum Moves
    {
        up,down,left,right,last
    }

    public Vector3 PlayerStartPosition;

    public float speed;
    public bool[] move;
    public int lives = 2;

    public delegate void OnPlayerHitted();
    public static OnPlayerHitted PlayerHit;

    void Start()
    {
        PlayerHit += PlayerHitBehaviour;
        move = new bool[(int)Moves.last];

        for(int i=0;i< (int)Moves.last; i++)
        {
            move[i] = true;
        }
    }

    void OnDestroy()
    {
        PlayerHit -= PlayerHitBehaviour;
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        if(!move[(int)Moves.right] && hor>0)
        {
            hor = 0;
        }
        if(!move[(int)Moves.left] && hor < 0)
        {
            hor = 0;
        }
        if(!move[(int)Moves.up] && ver > 0)
        {
            ver = 0;
        }
        if(!move[(int)Moves.down] && ver < 0)
        {
            ver = 0;
        }
       
        transform.position += new Vector3(hor, 0, ver)*speed*Time.deltaTime;
        if((Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space)))
        {
            BombManager.instance.SetBomb(transform.position);
        }
    }

    public int GetLives()
    {
        return lives;
    }

    void PlayerHitBehaviour()
    {
        lives--;
        if (lives > 0)
        {
            transform.position = PlayerStartPosition;
        }
        else
        {
            LevelManager.Get().GoToNextLevel();
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Enemy" && !EnemySpawner.pacmanmode)
        {
            PlayerHit();
        }
        else if(col.gameObject.tag=="Item")
        {
            col.gameObject.GetComponent<ItemBehaviour>().ActivateEffect();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Explosion")
        {
            PlayerHit();
        }
        else if (col.gameObject.tag == "Door")
        {
            if (col.GetComponent<DoorBehaviour>().able)
            {
                LevelManager.Get().GoToNextLevel();
            }
        }
    }
}
