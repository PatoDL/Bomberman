using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    public bool able = false;
    public bool exit = false;

    void OnTriggerEnter(Collider col)
    {
        if(able && col.gameObject.name=="Player")
        {
            exit = true;
        }
    }
}
