using App.Scripts.Game.Blocks.Factories.Base;
using App.Scripts.Game.Blocks.Shared.Base;
using App.Scripts.Game.Spawning.BlockProvider;
using UnityEngine;

namespace App.Scripts.Game.Blocks.Factories.MagnetBlockFactory
{
    public class MagnetBlockFactory : BlockFactory
    {
        [Header("Magnetization Options")] [SerializeField] [Min(0)]
        private float affectRadius;

        [SerializeField] [Min(0)] private float strengthMultiplier;
        
        [Header("Blocks Component")] [SerializeField]
        private BlockProvider blockProvider;
        
        public override Block Create()
        {
            var newPrefab = Instantiate(prefab, transform);
            
            newPrefab.OnChop += (x) =>
            {
                PullBlocks(newPrefab.transform.position);
            };

            return newPrefab;
        }

        private void PullBlocks(Vector3 position)
        {
            var affectedBlocks = blockProvider.SpawnedBlocks.FindAll(block =>
            {
                return Vector3.Distance(position, block.transform.position) < affectRadius &&
                       block.isPositive;
            });

            foreach (var affectedBlock in affectedBlocks)
            {
                Vector3 delta = position - affectedBlock.transform.position;
                float angle = Vector2.SignedAngle(Vector2.right, delta) ;
                float strength = affectRadius * strengthMultiplier;
                
                affectedBlock.SetForce(angle, strength);
            }
        }
    }
}