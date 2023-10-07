using System;
using App.Scripts.Game.Blocks.Shared.Abstract;
using UnityEngine;

namespace App.Scripts.Game.Spawning.BlockProvider.Scriptable
{
    [Serializable]
    public class BlockInfo
    {
        public Block prefab;
        
        [Min(0)] public float spawnWeight;
    }
}