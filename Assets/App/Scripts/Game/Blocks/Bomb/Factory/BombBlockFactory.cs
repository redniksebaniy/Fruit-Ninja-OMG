using App.Scripts.Game.Blocks.Shared.Base;
using App.Scripts.Game.Blocks.Shared.Base.Base;
using App.Scripts.Game.Features.ForcePointProvider;
using App.Scripts.Game.Features.HealthHandler;
using UnityEngine;

namespace App.Scripts.Game.Blocks.Bomb.Factory
{
    public class BombBlockFactory : BlockFactory
    {
        [Header("Push Blocks Component")] [SerializeField]
        private ForcePointProvider pushForcePointProvider;
        
        [Header("Remove Heart Component")] [SerializeField]
        private HealthHandler healthHandler;

        public override Block Create()
        {
            var newPrefab = Instantiate(prefab, transform);
            
            newPrefab.OnChop += (x) =>
            {
                healthHandler.RemoveHeart();
                pushForcePointProvider.CreateForcePoint(newPrefab.transform.position);
            };

            return newPrefab;
        }
    }
}