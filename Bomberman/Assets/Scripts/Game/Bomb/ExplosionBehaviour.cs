using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour
{
    float timer;
    private void Start()
    {
        timer = 0f;
        Physics.IgnoreLayerCollision(9, 10);
    }

    private void Update()
    {
        if (timer > 1f)
        {
            Destroy(this.gameObject);
        }
        timer += 1;
    }

    private void OnTriggerEnter(Collider col)
    {
        Destroy(this.gameObject);
    }

    
}
