using App.Scripts.Game.Blocks.Shared.Abstract;
using App.Scripts.Game.Spawning.BlockProvider.Scriptable;
using App.Scripts.Utilities.WeightHandler;
using UnityEngine;

namespace App.Scripts.Game.Spawning.BlockProvider
{
    public class BlockProvider : MonoBehaviour
    {
        [SerializeField] private BlockProviderScriptable providerScriptable;
        
        private readonly WeightHandler _weightHandler = new();

        private float[] _spawnWeights;

        private void Start()
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
        
        public Block GetWeightedBlock()
        {
            int index = _weightHandler.GetWeightedIndex(_spawnWeights);
            return providerScriptable.blocks[index].prefab;
        }
        
    }
}