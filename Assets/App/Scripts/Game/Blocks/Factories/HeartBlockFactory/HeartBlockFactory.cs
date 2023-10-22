using App.Scripts.Game.Blocks.Factories.Base;
using App.Scripts.Game.Blocks.Shared.Base;
using App.Scripts.Game.Features.HealthHandler;
using UnityEngine;

namespace App.Scripts.Game.Blocks.Factories.HeartBlockFactory
{
    public class HeartBlockFactory : BlockFactory
    {
        [Header("Add Heart Component")] [SerializeField]
        private HealthHandler healthHandler;
        
        public override Block Create()
        {
            if (healthHandler.IsFull()) return null;
            
            var newPrefab = Instantiate(prefab, transform);
            
            newPrefab.OnChop += (x) => healthHandler.AddHeart(newPrefab.transform.position, 1f);

            return newPrefab;
        }
    }
}