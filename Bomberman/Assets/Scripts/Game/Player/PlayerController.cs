using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum Moves
    {
        up,down,left,right
    }

    public GameObject bombPF;
    public GameManager explosionPF;

    public Vector3 PlayerStartPosition;

    public float speed;
    Vector3 zMovement;
    Vector3 xMovement;
    Rigidbody rig;
    const int cantMoves = 4;
    public bool[] move;
    public int lives = 2;

    public bool hittedByBomb = false;
    public bool hittedByEnemy = false;

    void Start()
    {
        PlayerStartPosition = new Vector3(1350.1f, 63.03f, 1447.1f);
        speed = 200.0f * Time.deltaTime;
        zMovement = new Vector3(0, 0, 1);
        xMovement = new Vector3(1, 0, 0);
        rig = GetComponent<Rigidbody>();
        move = new bool[cantMoves];

        for(int i=0;i<cantMoves;i++)
        {
            move[i] = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow) && move[(int)Moves.up])
        {
            transform.position += zMovement * speed;
            manageXInput(false);
        }
        if (Input.GetKey(KeyCode.DownArrow) && move[(int)Moves.down])
        {
            transform.position += zMovement * -speed;
            manageXInput(false);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && move[(int)Moves.left])
        {
            transform.position += xMovement * -speed;
            manageZInput(false);
        }
        if (Input.GetKey(KeyCode.RightArrow) && move[(int)Moves.right])
        {
            transform.position += xMovement * speed;
            manageZInput(false);
        }
        if((Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space))&&!BombBehaviour.GetInstanciated())
        {
            GameObject b = Instantiate(bombPF);
            b.name = "Bomb";
            b.transform.position = transform.position;
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            manageZInput(true);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            manageXInput(true);
        }
    }

    void manageXInput(bool b)
    {
        move[(int)Moves.right] = b;
        move[(int)Moves.left] = b;
    }

    void manageZInput(bool b)
    {
        move[(int)Moves.up] = b;
        move[(int)Moves.down] = b;
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name=="Enemy" && !hittedByEnemy)
        {
            hittedByEnemy = true;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Explosion" && !hittedByBomb)
        {
            hittedByBomb = true;
        }
    }
}
