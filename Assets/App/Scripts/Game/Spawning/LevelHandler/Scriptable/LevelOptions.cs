using System;
using UnityEngine;

namespace App.Scripts.Game.Spawning.LevelHandler.Scriptable
{
    [Serializable]
    public struct LevelOptions
    {
        [Header("Spawn Options")] [Min(0)] 
        public float timeBetweenPackSpawn;

        [Min(0)] 
        public int minBlockCount;
        
        [Min(0)] 
        public int maxBlockCount;
        
        [Min(0)] 
        public float timeBetweenBlockSpawn;
        
        [Header("Increase Difficulty Options")] [Min(0)] 
        public int spawnsBeforeIncrease;
        
        [Space(10)] [Range(0, 1)] 
        public float timeDecreasePercent;

        [Min(0)] 
        public int blockCountIncrease;
    }
}