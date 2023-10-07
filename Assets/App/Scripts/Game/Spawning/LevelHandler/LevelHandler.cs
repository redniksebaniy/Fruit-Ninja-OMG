using System.Collections;
using App.Scripts.Game.Blocks.Shared.Abstract;
using App.Scripts.Game.Spawning.LevelHandler.Scriptable;
using App.Scripts.Game.Spawning.BlockProvider;
using App.Scripts.Game.Spawning.FieldProvider;
using UnityEngine;

namespace App.Scripts.Game.Spawning.LevelHandler
{
    public class LevelHandler : MonoBehaviour
    {
        [SerializeField] private LevelOptionsScriptable optionsScriptable;

        [SerializeField] private BlockProvider.BlockProvider blockProvider;
        
        [SerializeField] private FieldProvider.FieldProvider fieldProvider;
        
        private void Start()
        {
            StartCoroutine(nameof(SpawnPacks));
        }

        private IEnumerator SpawnPacks()
        {
            while (true)
            {
                yield return new WaitForSeconds(optionsScriptable.timeBetweenSpawn);

                int blockCount = Random.Range(optionsScriptable.minBlockCount, optionsScriptable.maxBlockCount);
                while (blockCount > 0)
                {
                    SpawnBlock();
                    blockCount--;
                }
            }
        }

        private void SpawnBlock()
        {
            var field = fieldProvider.GetWeightedField();
            var block = blockProvider.GetWeightedBlock();

            var newBlock = Instantiate(block, field.GetRandomPosition(), Quaternion.identity);
            newBlock.SetForce(field.GetRandomAngle(), field.GetRandomStrength());
        }
        
    }
}