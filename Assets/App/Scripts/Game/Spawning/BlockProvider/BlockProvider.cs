using System.Collections.Generic;
using App.Scripts.Architecture.MonoInitializable;
using App.Scripts.Game.Blocks.Shared.Abstract;
using App.Scripts.Game.Spawning.BlockProvider.Scriptable;
using App.Scripts.Utilities.WeightConverter;
using UnityEngine;

namespace App.Scripts.Game.Spawning.BlockProvider
{
    public class BlockProvider : MonoInitializable
    {
        [SerializeField] private BlockProviderScriptable providerScriptable;
        
        private readonly WeightConverter _weightConverter = new();

        private float[] _spawnWeights;

        public readonly List<Block> SpawnedBlocks = new();
        
        public override void Init()
        {
            CollectWeights();
        }
        
        private void CollectWeights()
        {
            int count = providerScriptable.blocks.Length;
            _spawnWeights = new float[count];

            for (int i = 0; i < count; i++)
            {
                _spawnWeights[i] = providerScriptable.blocks[i].spawnWeight;
            }
        }
        
        private Block GetWeightedBlock()
        {
            int index = _weightConverter.GetWeightedIndex(_spawnWeights);
            return providerScriptable.blocks[index].prefab;
        }

        public Block SpawnWeightedBlock()
        {
            Block newBlock = Instantiate(GetWeightedBlock());
            SpawnedBlocks.Add(newBlock);

            return newBlock;
        }
    }
}