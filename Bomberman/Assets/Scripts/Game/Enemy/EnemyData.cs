using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[Serializable]
public class EnemyData
{
    public int lives = 3;
    public Vector3 direction = new Vector3(1, 0, 0);
    public PlayerController.Moves move = PlayerController.Moves.right;
    public float speed = 1.0f;
    public EnemyBehaviour.State state = EnemyBehaviour.State.idle;
}
