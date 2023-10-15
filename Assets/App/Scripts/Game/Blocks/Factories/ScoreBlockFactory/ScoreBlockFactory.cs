using App.Scripts.Game.Blocks.Factories.Abstract;
using App.Scripts.Game.Blocks.Score;
using App.Scripts.Game.Blocks.Shared.Abstract;
using App.Scripts.Game.Features.HealthHandler;
using App.Scripts.Game.Features.ScoreHandler;
using UnityEngine;
using UnityEngine.Events;

namespace App.Scripts.Game.Blocks.Factories.ScoreBlockFactory
{
    public class ScoreBlockFactory : BlockFactory
    {
        [SerializeField] private ScoreBlock prefab;
        
        public override Block Create()
        {
            var newPrefab = Instantiate(prefab, transform);
            
            newPrefab.OnChop += () => OnBlockChop?.Invoke();
            newPrefab.OnMiss += () => OnBlockMiss?.Invoke();

            return newPrefab;
        }
    }
}