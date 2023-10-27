using App.Scripts.Game.Blocks.Shared.Base;
using App.Scripts.Game.Blocks.Shared.Base.Base;
using App.Scripts.Game.Features.ForcePointProvider.Base;
using App.Scripts.Game.Spawning.BlockProvider;
using UnityEngine;

namespace App.Scripts.Game.Blocks.Magnet.Factory
{
    public class MagnetBlockFactory : BlockFactory
    {
        [Header("Magnet Blocks Component")] [SerializeField]
        private ForcePointProvider pullForcePointProvider;
        
        [Header("Blocks Component")] [SerializeField]
        private BlockProvider blockProvider;
        
        public override Block Create()
        {
            var newPrefab = Instantiate(prefab, transform);
            
            newPrefab.OnChop += (x) =>
            {
                pullForcePointProvider.CreateForcePoint(newPrefab.transform.position);
            };

            return newPrefab;
        }
    }
}