using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public enum ItemType
    {
        pacman,
        end,
    }

    public GameObject pacmanItemPF;
    GameObject[] items;
    int posibilityOfInstantiate = 7;
    public int amountOfItemsInstantiated;

    void Start()
    {
        items = new GameObject[(int)ItemType.end];
        items[(int)ItemType.pacman] = pacmanItemPF;
        DestroyableWallBehaviour.GenItem = InstantiateItem;
    }

    void InstantiateItem(ItemType i, Vector3 pos, int posibility)
    {
        if (posibility < posibilityOfInstantiate)
        {
            GameObject g = Instantiate(items[(int)i]);
            g.transform.position = pos;
            amountOfItemsInstantiated++;
            posibilityOfInstantiate--;
            if (posibilityOfInstantiate < 1)
                posibilityOfInstantiate = 1;
        }
    }
}
