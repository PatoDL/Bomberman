using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableWallGenerator : MonoBehaviour
{
    public GameObject floorController;
    GameObject floor;
    GameObject destroyableWallsParent;
    public GameObject destroyableWall;
    public GameObject DoorPF;
    bool doorLocated = false;

    void Start()
    {
        floor = floorController.transform.Find("Floor").gameObject;
        MakeDestroyableWalls();
    }

    void MakeDestroyableWalls()
    {
        destroyableWallsParent = new GameObject("DestroyableWallsParent");
        int destroyableWallsCount = 0;
        for (int x = (int)floorController.transform.position.x + 1; x < floor.transform.localScale.x / destroyableWall.transform.localScale.x; x++)
        {
            for (int z = (int)floorController.transform.position.x + 1; z < floor.transform.localScale.z / destroyableWall.transform.localScale.z; z++)
            {
                int r = Random.Range(0, 10);
                if ((x % 2 != 0 || (x % 2 == 0 && z % 2 != 0))
                    && r > 7 && destroyableWallsCount < 100 && (x!=13 || z!=14)
                    && (x>5||z>5) && (x< 20 || z<20) && (x >5 || z <20) && (x < 20 || z > 5))
                {
                    GameObject nw = Instantiate(destroyableWall);
                    
                    nw.transform.position = new Vector3(x * destroyableWall.transform.localScale.x + destroyableWall.transform.localScale.x / 2,
                        destroyableWall.transform.localScale.y/2, z * destroyableWall.transform.localScale.x + destroyableWall.transform.localScale.x / 2);
                    destroyableWallsCount++;
                    nw.tag = "DestroyableWall";
                    nw.name = "DestroyableWall";
                    nw.transform.SetParent(destroyableWallsParent.transform);
                    if(!doorLocated)
                    {
                        GameObject d = Instantiate(DoorPF);
                        d.gameObject.name = "ExitDoor";
                        d.transform.position = new Vector3(nw.transform.position.x, d.transform.localScale.y / 2, nw.transform.position.z);
                        doorLocated = true;
                    }
                }
            }
        }
    }
}
