using App.Scripts.Architecture.Factory;
using App.Scripts.Game.Blocks.Factories.Base;
using App.Scripts.Game.Blocks.Score;
using App.Scripts.Game.Blocks.Shared.Abstract;
using App.Scripts.Game.Features.HealthHandler;
using App.Scripts.Game.Features.ScoreHandler;
using UnityEngine;

namespace App.Scripts.Game.Blocks.Factories.ScoreBlockFactory
{
    public class ScoreBlockFactory : BlockFactory
    {
        [Header("Add Score Component")] [SerializeField]
        private ScoreHandler scoreHandler;

        [Header("Remove Heart Component")] [SerializeField]
        private HealthHandler healthHandler;
        
        public override Block Create()
        {
            var newPrefab = Instantiate(prefab, transform);
            
            newPrefab.OnChop += (x) => scoreHandler.AddScore(newPrefab.transform.position);
            newPrefab.OnMiss += healthHandler.RemoveHeart;

            return newPrefab;
        }
    }
}