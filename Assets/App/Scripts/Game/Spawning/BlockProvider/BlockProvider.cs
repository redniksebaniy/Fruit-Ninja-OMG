using System.Collections.Generic;
using App.Scripts.Architecture.MonoInitializable;
using App.Scripts.Game.Blocks.Shared.Base;
using App.Scripts.Game.Blocks.Shared.Base.Base;
using App.Scripts.Utilities.WeightConverter;
using UnityEngine;

namespace App.Scripts.Game.Spawning.BlockProvider
{
    public class BlockProvider : MonoInitializable
    {
        [SerializeField] private BlockFactory defaultBlockFactory;
        
        [SerializeField] private BlockInfo.BlockInfo[] spawnBlockInfos;
        
        public readonly List<Block> SpawnedBlocks = new();
        
        private readonly WeightConverter _weightConverter = new();

        private float[] _percentInPack;
        private int[] _spawnWeights;

        private float _deltaBlockInPack;
        
        public override void Init()
        {
            _percentInPack = new float[spawnBlockInfos.Length];
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

            if (_percentInPack[index] + _deltaBlockInPack > spawnBlockInfos[index].maxPercentInPack)
            {
                return defaultBlockFactory;
            }
            
            _percentInPack[index] += _deltaBlockInPack;
            
            return spawnBlockInfos[index].factory;
        }

        public Block SpawnWeightedBlock()
        {
            var newBlock = GetWeightedBlockFactory().Create() ?? defaultBlockFactory.Create();
            SpawnedBlocks.Add(newBlock);
            newBlock.SetInvulnerability();
            
            newBlock.OnChop += (x) => 
            {
                if (newBlock.IsDestroyableByChop) SpawnedBlocks.Remove(newBlock);
            };
            
            newBlock.OnMiss += () => SpawnedBlocks.Remove(newBlock);
            
            return newBlock;
        }
        
        public Block SpawnBlock(BlockFactory factory)
        {
            var newBlock = factory == null ? defaultBlockFactory.Create() : 
                factory.Create() ?? defaultBlockFactory.Create();
            SpawnedBlocks.Add(newBlock);
            newBlock.SetInvulnerability();
            
            newBlock.OnChop += (x) => 
            {
                if (newBlock.IsDestroyableByChop) SpawnedBlocks.Remove(newBlock);
            };
            
            newBlock.OnMiss += () => SpawnedBlocks.Remove(newBlock);
            
            return newBlock;
        }
        
        public void SetBlockInPack(int count)
        {
            _deltaBlockInPack = 1f / count;
            for (int i = 0; i < _percentInPack.Length; i++) _percentInPack[i] = 0;
        }
    }
}