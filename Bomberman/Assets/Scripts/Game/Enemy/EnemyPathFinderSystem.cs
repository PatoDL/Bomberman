using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathFinderSystem : AllignmentTriggers
{
    EnemyBehaviour e;

    public override void Start()
    {
        base.Start();
        e = GetComponentInParent<EnemyBehaviour>();
    }

    void SearchPreferencedPath(string colName)
    {
        Transform en = parent.transform;
        Transform p = e.player.transform;
        switch(colName)
        {
            case "ColliderX":
                bool playerOnTheRight = p.position.x > en.position.x;
                if (playerOnTheRight)
                    e.prefX = (int)PlayerController.Moves.right;
                else
                    e.prefX = (int)PlayerController.Moves.left;
                break;
            case "ColliderZ":
                bool playerUp = p.position.z > en.position.z;
                if (playerUp)
                    e.prefZ = (int)PlayerController.Moves.up;
                else
                    e.prefZ = (int)PlayerController.Moves.down;
                break;
        }
    }

    void ManagePathsZ(GameObject g, bool activated)
    {
        Transform t = g.transform;
        Transform p = parent.transform;

        bool upWall = t.position.z > p.position.z;

        if (upWall)
        {
            e.lockedWays[(int)PlayerController.Moves.up] = activated;
        }
        else
        {
            e.lockedWays[(int)PlayerController.Moves.down] = activated;
        }
    }

    void ManagePathsX(GameObject g, bool activated)
    {
        Transform t = g.transform;
        Transform p = parent.transform;

        bool rightWall = t.position.x > p.position.x;

        if (rightWall)
        {
            e.lockedWays[(int)PlayerController.Moves.right] = activated;
        }
        else
        {
            e.lockedWays[(int)PlayerController.Moves.left] = activated;
        }
    }

    public override void OnTriggerStay(Collider col)
    {
        base.OnTriggerStay(col);

        switch(gameObject.name)
        {
            case "ColliderX":
                ManagePathsX(col.gameObject, true);
                break;
            case "ColliderZ":
                ManagePathsZ(col.gameObject, true);
                break;
        }
        SearchPreferencedPath(gameObject.name);
    }

    public void OnTriggerExit(Collider col)
    {
        switch (gameObject.name)
        {
            case "ColliderX":
                ManagePathsX(col.gameObject,false);
                break;
            case "ColliderZ":
                ManagePathsZ(col.gameObject, false);
                break;
        }
        SearchPreferencedPath(gameObject.name);
    }
}
