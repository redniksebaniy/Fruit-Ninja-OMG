using System;
using App.Scripts.Game.Blocks.Shared.Base.Base;
using UnityEngine;

namespace App.Scripts.Game.Spawning.BlockProvider.BlockInfo
{
    [Serializable]
    public class BlockInfo
    {
        public BlockFactory factory;
        
        [Min(0)] public int spawnWeight;

        [Range(0, 1)] public float maxPercentInPack;
    }
}