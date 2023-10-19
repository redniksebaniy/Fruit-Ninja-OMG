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
        
        private LevelOptions _currentOptions;

        private float _time;
        private bool _isSpawning;
        
        private int _packCount = 1;
        private int _blockCount;
        
        public override void Init()
        {
            Application.targetFrameRate = optionsScriptable.targetFrameRate;
            _currentOptions = optionsScriptable.level;
            
            _isSpawning = false;
        }
        
        public void Update()
        {
            _time += Time.deltaTime;

            if (_isSpawning) CheckForBlocksSpawn();
            else CheckForPackSpawn();
        }

        private void CheckForPackSpawn()
        {
            if (_time <= _currentOptions.timeBetweenPackSpawn) return;
            
            _time -= _currentOptions.timeBetweenPackSpawn;
            
            _blockCount = Random.Range(_currentOptions.minBlockCount, _currentOptions.maxBlockCount + 1);

            _isSpawning = true;
            
            if (_packCount++ % _currentOptions.spawnsBeforeIncrease == 0)
            {
                IncreaseDifficulty();
            }
        }

        private void CheckForBlocksSpawn()
        {
            if (_time <= _currentOptions.timeBetweenBlockSpawn) return;
            
            _time -= _currentOptions.timeBetweenBlockSpawn;
            
            SpawnBlock();

            if (--_blockCount == 0) _isSpawning = false;
        }
        
        private void IncreaseDifficulty()
        {
            _currentOptions.minBlockCount += _currentOptions.blockCountIncrease;
            _currentOptions.maxBlockCount += _currentOptions.blockCountIncrease;

            _currentOptions.timeBetweenPackSpawn *= 1 - _currentOptions.timeDecreasePercent;
            _currentOptions.timeBetweenBlockSpawn *= 1 - _currentOptions.timeDecreasePercent;
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