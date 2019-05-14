using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    GameObject floor;
    GameObject normalWall;
    void Start()
    {
        MakeFloor();
        MakeNormalWalls();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeFloor()
    {
        floor = GameObject.CreatePrimitive(PrimitiveType.Cube);
        floor.transform.localScale = new Vector3(2000, 1, 2000);
        floor.transform.position = Vector3.zero;
        floor.name = "Floor";
    }

    void MakeNormalWalls()
    {
        normalWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        normalWall.transform.localScale = new Vector3(1, 1, 1);
        normalWall.GetComponent<MeshRenderer>().material.color = Color.red;
        for(int i=0;i<floor.transform.localScale.x;i++)
        {
            GameObject nw = Instantiate(normalWall);
            nw.transform.position = new Vector3(i * normalWall.transform.localScale.x, 1, i * normalWall.transform.localScale.x);
        }
    }
}
