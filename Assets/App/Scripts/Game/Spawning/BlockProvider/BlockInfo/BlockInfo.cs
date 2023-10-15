using System;
using App.Scripts.Game.Blocks.Factories.Abstract;
using UnityEngine;

namespace App.Scripts.Game.Spawning.BlockProvider.Scriptable
{
    [Serializable]
    public class BlockInfo
    {
        public BlockFactory factory;
        
        [Min(0)] public int spawnWeight;
    }
}