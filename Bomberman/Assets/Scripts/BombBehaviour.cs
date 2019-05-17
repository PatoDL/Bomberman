using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehaviour : MonoBehaviour
{
    float timer;
    bool activeTimer;
    static bool instanciated;

    void Start()
    {
        timer = 0.0f;
        instanciated = true;
        activeTimer = false;
    }

    void Update()
    {
        if (activeTimer)
        {
            timer += Time.deltaTime;
            if (timer > 2.5f)
            {
                instanciated = false;
                Destroy(this.gameObject);
            }
        }
    }

    public static bool GetInstanciated()
    {
        return instanciated;
    }

    private void OnTriggerExit(Collider col)
    {
        if(col.gameObject.name=="Sphere")
        {
            activeTimer = true;
            GetComponent<SphereCollider>().isTrigger = false;
            gameObject.AddComponent<Rigidbody>();
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
