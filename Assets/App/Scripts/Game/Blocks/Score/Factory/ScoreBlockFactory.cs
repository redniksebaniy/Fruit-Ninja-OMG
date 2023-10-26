using App.Scripts.Game.Blocks.Shared.Base;
using App.Scripts.Game.Blocks.Shared.Base.Base;
using App.Scripts.Game.Features.HealthHandler;
using App.Scripts.Game.Features.ScoreHandler;
using UnityEngine;

namespace App.Scripts.Game.Blocks.Score.Factory
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