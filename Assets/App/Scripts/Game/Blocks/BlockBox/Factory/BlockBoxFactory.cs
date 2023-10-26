using App.Scripts.Game.Blocks.Shared.Base;
using App.Scripts.Game.Blocks.Shared.Base.Base;
using App.Scripts.Game.Spawning.BlockProvider;
using App.Scripts.Game.Spawning.LevelHandler;
using UnityEngine;

namespace App.Scripts.Game.Blocks.BlockBox.Factory
{
    public class BlockBoxFactory : BlockFactory
    {
        [SerializeField] private LevelHandler levelHandler;
        
        [SerializeField] private BlockProvider blockProvider;
        
        [SerializeField] private BlockFactory insideFactory;

        [SerializeField] [Min(0)] private int blockCount;

        public override Block Create()
        {
            var newPrefab = Instantiate(prefab, transform);
            
            newPrefab.OnChop += (x) =>
            {
                for (int i = 0; i < blockCount; i++)
                {
                    var block = blockProvider.SpawnBlock(insideFactory);
                    block.transform.SetPositionAndRotation(newPrefab.transform.position, Quaternion.identity);
                    levelHandler.SetDefaultForce(block);
                }
            };

            return newPrefab;
        }
    }
}