using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    public bool able = false;

    void Start()
    {
        EnemySpawner.ActivateDoor = ActivateDoor;
    }

    void ActivateDoor()
    {
        able = true;
    }
}
