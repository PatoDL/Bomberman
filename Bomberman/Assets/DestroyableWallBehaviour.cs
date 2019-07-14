using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableWallBehaviour : MonoBehaviour
{
    public delegate void OnWallDestroy(ItemManager.ItemType i,Vector3 pos, int posibility);
    public static OnWallDestroy GenItem;

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.layer == 10)
        {
            GenItem(ItemManager.ItemType.pacman, transform.position, Random.Range(0, 10));
            Destroy(this.gameObject);
        }
    }
}
