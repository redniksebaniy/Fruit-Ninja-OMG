using System.Collections.Generic;
using App.Scripts.Architecture.MonoInitializable;
using App.Scripts.Game.Blocks.Factories.Base;
using App.Scripts.Game.Blocks.Shared.Abstract;
using App.Scripts.Utilities.WeightConverter;
using UnityEngine;

namespace App.Scripts.Game.Spawning.BlockProvider
{
    public class BlockProvider : MonoInitializable
    {
        [SerializeField] private BlockInfo.BlockInfo[] spawnBlockInfos;
        
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
            
            newBlock.OnChop += (x) => Remove(newBlock);
            newBlock.OnMiss += () => Remove(newBlock);
            
            return newBlock;
        }

        public void Remove(Block block)
        {
            SpawnedBlocks.Remove(block);
        }
    }
}