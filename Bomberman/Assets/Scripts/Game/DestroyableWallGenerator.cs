using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableWallGenerator : MonoBehaviour
{
    public GameObject destroyableWallPF;
    public GameObject doorPF;
    public GameObject floor;
    public GameObject destroyableWallsParent;
    bool doorLocated = false;

    void Start()
    {
        GenerateDestroyableWalls();
    }

    void GenerateDestroyableWalls()
    {
        int destroyableWallsCount = 0;
        float xLimit = floor.transform.localScale.x / destroyableWallPF.transform.localScale.x / 2;
        float zLimit = floor.transform.localScale.z / destroyableWallPF.transform.localScale.z / 2;
        int startLimit = -12;

        for (int x = startLimit; x < xLimit; x++)
        {
            for (int z = startLimit; z < zLimit; z++)
            {
                int r = Random.Range(0, 10);

                bool notCentre = !(x <= 1 && x>=-1 && z >= -1 && z<=1);

                bool notInNormalWallsPosition = !(z % 2 != 0 && x % 2 != 0);

                bool notInLimits = !((x >= xLimit - 1 && z >= zLimit - 1) || (x == startLimit && z == startLimit) ||
                                    (x >= xLimit - 1 && z == startLimit) || (x == startLimit && z >= zLimit - 1));

                if (r < 2 && destroyableWallsCount < 200)
                {
                    if (notCentre && notInNormalWallsPosition && notInLimits)
                    {
                        GameObject dw = Instantiate(destroyableWallPF);

                        dw.transform.position = new Vector3(x * destroyableWallPF.transform.localScale.x,
                            destroyableWallPF.transform.localScale.y, z * destroyableWallPF.transform.localScale.z);
                        destroyableWallsCount++;
                        dw.tag = "DestroyableWall";
                        dw.name = "DestroyableWall";
                        dw.transform.SetParent(destroyableWallsParent.transform);
                        if (!doorLocated)
                        {
                            GameObject d = Instantiate(doorPF);
                            d.gameObject.name = "ExitDoor";
                            d.transform.position = new Vector3(dw.transform.position.x, d.transform.position.y,
                                dw.transform.position.z);
                            doorLocated = true;
                        }
                    }
                }
            }
        }
    }
}
