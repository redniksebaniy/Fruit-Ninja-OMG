using System.Collections.Generic;
using App.Scripts.Architecture.MonoInitializable;
using App.Scripts.Game.Blocks.Factories.Abstract;
using App.Scripts.Game.Blocks.Shared.Abstract;
using App.Scripts.Game.Spawning.BlockProvider.Scriptable;
using App.Scripts.Utilities.WeightConverter;
using UnityEngine;

namespace App.Scripts.Game.Spawning.BlockProvider
{
    public class BlockProvider : MonoInitializable
    {
        [SerializeField] private BlockInfo[] spawnBlockInfos;
        
        public readonly List<Block> SpawnedBlocks = new();
        
        private readonly WeightConverter _weightConverter = new();

        private int[] _spawnWeights;
        
        public override void Init()
        {
            CollectWeights();
        }
        
        private void CollectWeights()
        {
            int count = spawnBlockInfos.Length;
            _spawnWeights = new int[count];

            for (int i = 0; i < count; i++)
            {
                _spawnWeights[i] = spawnBlockInfos[i].spawnWeight;
            }
        }
        
        private BlockFactory GetWeightedBlockFactory()
        {
            int index = _weightConverter.GetWeightedIndex(_spawnWeights);
            return spawnBlockInfos[index].factory;
        }

        public Block SpawnWeightedBlock()
        {
            var newBlock = GetWeightedBlockFactory().Create();
            SpawnedBlocks.Add(newBlock);

            return newBlock;
        }

        public void CleanDeletedBlocks()
        {
            SpawnedBlocks.RemoveAll(block => block == null);
        }
    }
}