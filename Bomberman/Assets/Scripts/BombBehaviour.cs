using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehaviour : MonoBehaviour
{
    float timer;
    bool activeTimer;
    static bool instanciated;
    public GameObject explosionPF;
    const int cantExplosions=4;

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
                Explode();
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

    void Explode()
    {
        GameObject e1 = Instantiate(explosionPF);
        e1.transform.position = new Vector3(transform.position.x - explosionPF.transform.localScale.x, transform.position.y, transform.position.z);
        GameObject e2 = Instantiate(explosionPF);
        e2.transform.position = new Vector3(transform.position.x + explosionPF.transform.localScale.x, transform.position.y, transform.position.z);
        GameObject e3 = Instantiate(explosionPF);
        e3.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - explosionPF.transform.localScale.z);
        GameObject e4 = Instantiate(explosionPF);
        e4.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + explosionPF.transform.localScale.z);
    }
}
