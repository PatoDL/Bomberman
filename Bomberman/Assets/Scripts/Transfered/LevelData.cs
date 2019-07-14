using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    public int level;
    new public string name;

    public int nextLevel;
    public int previousLevel;

    public delegate void OnLevelDataPass(LevelData levelData);
    public static OnLevelDataPass PassLevelData;

    void Start()
    {
        PassLevelData(this);
    }
    
}
