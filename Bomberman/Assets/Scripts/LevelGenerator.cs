using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    GameObject floorController;
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
        floorController = new GameObject("FloorController");
        floorController.transform.position = new Vector3(0, 0, 0);
        floor = GameObject.CreatePrimitive(PrimitiveType.Cube);
        floor.transform.SetParent(floorController.transform);
        floor.GetComponent<MeshRenderer>().material.color = Color.green;
        floor.transform.localScale = new Vector3(2000, 1, 2000);
        floor.transform.position = floorController.transform.position + new Vector3(floor.transform.localScale.x / 2, 0, floor.transform.localScale.x / 2);
        floor.name = "Floor";
    }

    void MakeNormalWalls()
    {
        normalWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        normalWall.transform.localScale = new Vector3(100,50,100);
        normalWall.GetComponent<MeshRenderer>().material.color = Color.red;
        for (int i = (int)floorController.transform.position.x; i < floor.transform.localScale.x / normalWall.transform.localScale.x; i++)
        {
            GameObject nwx = Instantiate(normalWall);
            nwx.transform.position = new Vector3(i * normalWall.transform.localScale.x + normalWall.transform.localScale.x / 2,
                normalWall.transform.localScale.y / 2, floorController.transform.position.z + normalWall.transform.localScale.x / 2);
            nwx.tag = "x";
            GameObject nwz = Instantiate(normalWall);
            nwz.transform.position = new Vector3(floorController.transform.position.x + normalWall.transform.localScale.x / 2,
                normalWall.transform.localScale.y / 2, i * normalWall.transform.localScale.x + normalWall.transform.localScale.x / 2);
            nwz.tag = "z";
        }

        for (int i = (int)floor.transform.localScale.x / (int)normalWall.transform.localScale.x; i >= 0; i--)
        {
            GameObject nwX = Instantiate(normalWall);
            nwX.transform.position = new Vector3(i * normalWall.transform.localScale.x + normalWall.transform.localScale.x / 2,
                normalWall.transform.localScale.y/2, floor.transform.localScale.z + normalWall.transform.localScale.x / 2);
            nwX.tag = "x";
            GameObject nwZ = Instantiate(normalWall);
            nwZ.transform.position = new Vector3(floor.transform.localScale.x + normalWall.transform.localScale.x / 2,
                normalWall.transform.localScale.y / 2, i * normalWall.transform.localScale.x + normalWall.transform.localScale.x / 2);
            nwZ.tag = "z";
        }

        for (int x = (int)floorController.transform.position.x + 2; x < floor.transform.localScale.x / normalWall.transform.localScale.x; x += 2)
        {
            for (int z = (int)floorController.transform.position.x + 2; z < floor.transform.localScale.x / normalWall.transform.localScale.x; z += 2)
            {
                GameObject nw = Instantiate(normalWall);
                nw.transform.position = new Vector3(x * normalWall.transform.localScale.x + normalWall.transform.localScale.x / 2,
                    normalWall.transform.localScale.y / 2, z * normalWall.transform.localScale.x + normalWall.transform.localScale.x / 2);
            }
        }

        for (int x = (int)floorController.transform.position.x + 1; x < floor.transform.localScale.x / normalWall.transform.localScale.x; x ++)
        {
            for (int z = (int)floorController.transform.position.x + 1; z < floor.transform.localScale.x / normalWall.transform.localScale.x; z ++)
            {
                int r = Random.Range(0, 10);
                if ((x % 2 != 0 || (x % 2 == 0 && z % 2 != 0)) && r>7)
                {
                    GameObject nw = Instantiate(normalWall);
                    nw.GetComponent<MeshRenderer>().material.color = Color.grey;
                    nw.transform.position = new Vector3(x * normalWall.transform.localScale.x + normalWall.transform.localScale.x / 2,
                        normalWall.transform.localScale.y / 2, z * normalWall.transform.localScale.x + normalWall.transform.localScale.x / 2);
                }
            }
        }

        normalWall.SetActive(false);
    }
}
