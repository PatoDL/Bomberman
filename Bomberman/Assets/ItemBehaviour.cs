using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    public ItemManager.ItemType type;
    float duration;

    public delegate void OnPacmanActivation();
    public static OnPacmanActivation ActivatePacmanMode;

    void Start()
    {
        duration = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(duration>5f)
        {
            Destroy(this.gameObject);
        }
        duration += Time.deltaTime;
    }

    public void ActivateEffect()
    {
        switch (type)
        {
            case ItemManager.ItemType.pacman:
                ActivatePacmanMode();
                Destroy(this.gameObject);
                break;
        }
    }
}
