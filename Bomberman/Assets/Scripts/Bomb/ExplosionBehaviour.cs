using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour
{
    float timer;
    private void Start()
    {
        timer = 0f;
    }

    private void Update()
    {
        if (timer > 0f)
        {
            Destroy(this.gameObject);
        }
        timer += 1;
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name=="DestroyableWall")
        {
            Destroy(col.gameObject);
        }
        Destroy(this.gameObject);
    }

    
}
