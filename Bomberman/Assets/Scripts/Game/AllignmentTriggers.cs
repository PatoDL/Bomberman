using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllignmentTriggers : MonoBehaviour
{
    [HideInInspector] public GameObject parent;
    PlayerController playerController;

    public virtual void Start()
    {
        parent = transform.parent.gameObject;
        playerController = parent.GetComponent<PlayerController>();
        Physics.IgnoreLayerCollision(8, 9);
        Physics.IgnoreLayerCollision(9, 9);
        Physics.IgnoreLayerCollision(9, 10);
        Physics.IgnoreLayerCollision(9, 12);
        Physics.IgnoreLayerCollision(9, 11);
        Physics.IgnoreLayerCollision(9, 13);
        Physics.IgnoreLayerCollision(9, 14);
    }

    void SetDistanceX(GameObject wall)
    {
        Transform w = wall.transform;
        Transform p = parent.transform;

        bool rightWall = w.position.x > p.position.x;

        if (rightWall)
        {
            float minDistance = w.position.x - w.localScale.x;
            bool mustAllign = p.position.x >= minDistance;
            if (mustAllign)
            {
                if(playerController)
                    playerController.move[(int)PlayerController.Moves.right] = false;
                p.position = new Vector3(minDistance, p.position.y, p.position.z);
            }
        }
        else 
        {
            float minDistance = w.position.x + w.localScale.x;
            bool mustAllign = p.position.x <= minDistance;
            if (mustAllign)
            {
                if (playerController)
                    playerController.move[(int)PlayerController.Moves.left] = false;
                p.position = new Vector3(minDistance, p.position.y, p.position.z);
            }
        }
    }

    void SetDistanceZ(GameObject wall)
    {
        Transform w = wall.transform;
        Transform p = parent.transform;

        bool upWall = w.position.z > p.position.z;

        if (upWall)
        {
            bool mustAllign = p.position.z >= w.position.z - w.localScale.z;
            if (mustAllign)
            {
                if (playerController)
                    playerController.move[(int)PlayerController.Moves.up] = false;
                p.position = new Vector3(p.position.x, p.position.y, w.position.z - w.localScale.z);
            }
        }
        else
        {
            bool mustAllign = p.position.z <= w.position.z + w.localScale.z;
            if (mustAllign)
            {
                if (playerController)
                    playerController.move[(int)PlayerController.Moves.down] = false;
                p.position = new Vector3(p.position.x, p.position.y, w.position.z + w.localScale.z);
            }
        }
    }

    void FreeMovementX(GameObject wall)
    {
        Transform w = wall.transform;
        Transform p = parent.transform;

        bool rightWall = w.position.x > p.position.x;

        if (rightWall)
        {
            playerController.move[(int)PlayerController.Moves.right] = true;
        }
        else
        {
            playerController.move[(int)PlayerController.Moves.left] = true;
        }
    }

    void FreeMovementZ(GameObject wall)
    {
        Transform w = wall.transform;
        Transform p = parent.transform;

        bool upWall = w.position.z > p.position.z;

        if (upWall)
        {
            playerController.move[(int)PlayerController.Moves.up] = true;
        }
        else
        {
            playerController.move[(int)PlayerController.Moves.down] = true;
        }
    }

    public virtual void OnTriggerStay(Collider col)
    {
        switch (gameObject.name)
        {
            case "ColliderX":
                SetDistanceX(col.gameObject);
                break;
            case "ColliderZ":
                SetDistanceZ(col.gameObject);
                break;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (parent.name == "Player")
        {
            switch (gameObject.name)
            {
                case "ColliderX":
                    FreeMovementX(col.gameObject);
                    break;
                case "ColliderZ":
                    FreeMovementZ(col.gameObject);
                    break;
            }
        }
    }
}
