using App.Scripts.Architecture.MonoInitializable;
using App.Scripts.Game.Spawning.LevelHandler.Scriptable;
using UnityEngine;

namespace App.Scripts.Game.Spawning.LevelHandler
{
    public class LevelHandler : MonoInitializable
    {
        [SerializeField] private LevelOptionsScriptable optionsScriptable;

        [SerializeField] private BlockProvider.BlockProvider blockProvider;
        
        [SerializeField] private FieldProvider.FieldProvider fieldProvider;

        private LevelOptionsScriptable _currentOptions;

        private int _packCount;
        
        private float _time;
        
        public override void Init()
        {
            _currentOptions = Instantiate(optionsScriptable);
        }
        
        public void Update()
        {
            _time += Time.deltaTime;

            CheckForSpawn();
        }

        private void CheckForSpawn()
        {
            if (_time <= _currentOptions.timeBetweenSpawn) return;
            
            _time -= _currentOptions.timeBetweenSpawn;
            
            int blockCount = Random.Range(_currentOptions.minBlockCount, _currentOptions.maxBlockCount + 1);
            while (blockCount-- > 0)
            {
                SpawnBlock();
            }

            if (++_packCount % _currentOptions.spawnsBeforeIncrease == 0)
            {
                IncreaseDifficulty();
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
            var newBlock = blockProvider.SpawnWeightedBlock();

            newBlock.transform.SetPositionAndRotation(field.GetRandomPosition(), Quaternion.identity);
            newBlock.SetForce(field.GetRandomAngle(), field.GetRandomStrength());
        }
        
    }
}