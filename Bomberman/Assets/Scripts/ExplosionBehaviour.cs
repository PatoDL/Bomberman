using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name=="DestroyableWall")
        {
            Destroy(col.gameObject);
        }
    }
}
