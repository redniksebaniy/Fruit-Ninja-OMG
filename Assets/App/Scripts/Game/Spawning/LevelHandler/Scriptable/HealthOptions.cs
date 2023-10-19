using System;
using UnityEngine;

namespace App.Scripts.Game.Spawning.LevelHandler.Scriptable
{
    [Serializable]
    public struct HealthOptions
    {
        [Min(1)] 
        public int startHealthCount;

        [Min(1)] 
        public int maxHealthCount;
    }
}