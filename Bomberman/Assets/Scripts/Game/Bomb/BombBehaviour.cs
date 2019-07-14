using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehaviour : MonoBehaviour
{
    public delegate void OnBombExplode();
    public static OnBombExplode ExplodeBomb;

    float timer;
    bool activeTimer;
    public GameObject explosionPF;
    const int cantExplosions=4;

    void Start()
    {
        timer = 0.0f;
        activeTimer = false;
        ExplodeBomb += Explode;
    }

    void OnDestroy()
    {
        ExplodeBomb -= Explode;
    }

    void Update()
    {
        if (activeTimer)
        {
            timer += Time.deltaTime;
            if (timer > 2.5f)
            {
                ExplodeBomb();
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if(col.gameObject.name=="Player")
        {
            activeTimer = true;
            GetComponent<SphereCollider>().isTrigger = false;
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    void Explode()
    {
        Debug.Log("explita");
        GameObject e1 = Instantiate(explosionPF);
        e1.name = "Explosion";
        e1.transform.position = new Vector3(transform.position.x - explosionPF.transform.localScale.x, transform.position.y, transform.position.z);
        GameObject e2 = Instantiate(explosionPF);
        e2.name = "Explosion";
        e2.transform.position = new Vector3(transform.position.x + explosionPF.transform.localScale.x, transform.position.y, transform.position.z);
        GameObject e3 = Instantiate(explosionPF);
        e3.name = "Explosion";
        e3.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - explosionPF.transform.localScale.z);
        GameObject e4 = Instantiate(explosionPF);
        e4.name = "Explosion";
        e4.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + explosionPF.transform.localScale.z);
    }
}
