using System.Collections;
using App.Scripts.Game.Spawning.LevelHandler.Scriptable;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace App.Scripts.Game.Spawning.LevelHandler
{
    public class LevelHandler : MonoBehaviour
    {
        [SerializeField] private LevelOptionsScriptable optionsScriptable;

        [SerializeField] private BlockProvider.BlockProvider blockProvider;
        
        [SerializeField] private FieldProvider.FieldProvider fieldProvider;

        private LevelOptionsScriptable _currentOptions;
        
        private void Start()
        {
            Init();
            StartCoroutine(nameof(SpawnPacks));
        }

        private void Init()
        {
            _currentOptions = Instantiate(optionsScriptable);
        }
        
        private IEnumerator SpawnPacks()
        {
            int packCount = 0;
            while (true)
            {
                yield return new WaitForSeconds(_currentOptions.timeBetweenSpawn);

                int blockCount = Random.Range(_currentOptions.minBlockCount, _currentOptions.maxBlockCount + 1);
                while (blockCount-- > 0)
                {
                    SpawnBlock();
                }
                
                if (++packCount % _currentOptions.spawnsBeforeIncrease == 0)
                {
                    IncreaseDifficulty();
                }
            }
        }

        private void IncreaseDifficulty()
        {
            _currentOptions.minBlockCount += _currentOptions.blockCountIncrease;
            _currentOptions.maxBlockCount += _currentOptions.blockCountIncrease;

            _currentOptions.timeBetweenSpawn *= 1 - _currentOptions.timeDecreasePercent;
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