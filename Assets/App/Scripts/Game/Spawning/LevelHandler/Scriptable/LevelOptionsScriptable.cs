﻿using UnityEngine;

namespace App.Scripts.Game.Spawning.LevelHandler.Scriptable
{
    [CreateAssetMenu(fileName = "Level Options", menuName = "Scriptable Objects/Level Config", order = 0)]
    public class LevelOptionsScriptable : ScriptableObject
    {
        [Header("Spawn Options")]
        [Min(0)] public float timeBetweenSpawn;

        [Min(0)] public int minBlockCount;
        
        [Min(0)] public int maxBlockCount;
        
        [Header("Increase Difficulty Options")] 
        [Min(0)] public int spawnsBeforeIncrease;
        
        [Range(0, 1)] public float timeDecreasePercent;

        [Min(0)] public int blockCountIncrease;
        
    }
}