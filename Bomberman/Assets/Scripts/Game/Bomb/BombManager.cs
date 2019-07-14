using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : MonoBehaviour
{
    public int totalBombAmount;
    int bombSetCount = 0;
    public GameObject bombPF;

    public static BombManager instance;

    void Awake()
    {
        if(instance)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public static BombManager Get()
    {
        return instance;
    }

    void Start()
    {
        BombBehaviour.ExplodeBomb += UpdateBombAmount;
    }

    void OnDestroy()
    {
        BombBehaviour.ExplodeBomb -= UpdateBombAmount;
    }

    public void SetBomb(Vector3 pos)
    {
        if (bombSetCount < totalBombAmount)
        {
            GameObject g = Instantiate(bombPF);
            g.transform.position = pos;
            g.name = "Bomb";
            bombSetCount++;
        }
    }

    void UpdateBombAmount()
    {
        bombSetCount--;
    }
}
