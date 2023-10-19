using System;
using App.Scripts.Game.Blocks.Factories.Base;
using UnityEngine;

namespace App.Scripts.Game.Spawning.BlockProvider.BlockInfo
{
    [Serializable]
    public class BlockInfo
    {
        public BlockFactory factory;
        
        [Min(0)] public int spawnWeight;
    }
}