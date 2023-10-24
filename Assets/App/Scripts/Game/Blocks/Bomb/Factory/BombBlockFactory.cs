using App.Scripts.Game.Blocks.Shared.Base;
using App.Scripts.Game.Blocks.Shared.Base.Base;
using App.Scripts.Game.Features.HealthHandler;
using App.Scripts.Game.Spawning.BlockProvider;
using UnityEngine;

namespace App.Scripts.Game.Blocks.Bomb.Factory
{
    public class BombBlockFactory : BlockFactory
    {
        [Header("Explosion Options")] [SerializeField] [Min(0)]
        private float affectRadius;

        [SerializeField] [Min(0)] private float strengthMultiplier;
        
        [Header("Blocks Component")] [SerializeField]
        private BlockProvider blockProvider;
        
        [Header("Remove Heart Component")] [SerializeField]
        private HealthHandler healthHandler;

        public override Block Create()
        {
            var newPrefab = Instantiate(prefab, transform);
            
            newPrefab.OnChop += (x) =>
            {
                healthHandler.RemoveHeart();
                PushBlocks(newPrefab.transform.position);
            };

            return newPrefab;
        }

        private void PushBlocks(Vector3 position)
        {
            var affectedBlocks = blockProvider.SpawnedBlocks.FindAll(block =>
            {
                return Vector3.Distance(position, block.transform.position) < affectRadius;
            });

            foreach (var affectedBlock in affectedBlocks)
            {
                Vector3 delta = affectedBlock.transform.position - position;
                float angle = Vector2.SignedAngle(Vector2.right, delta) ;
                float strength = affectRadius * strengthMultiplier / (delta.magnitude > 1 ? delta.magnitude : 1);
                
                affectedBlock.SetForce(angle, strength);
            }
        }
        
    }
}