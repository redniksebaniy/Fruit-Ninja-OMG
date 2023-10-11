using App.Scripts.Game.Spawning.BlockProvider;
using UnityEngine;

namespace App.Scripts.Input.Chopper
{
    public class Chopper : MonoBehaviour
    {
        [SerializeField] private SwipeInputObserver.SwipeInputObserver observer;

        [SerializeField] private BlockProvider blockProvider;
        
        private void Update()
        {
            if (!observer.IsValidSwipe()) return;
            
            Vector3 chopperPosition = transform.position;

            blockProvider.CleanDeletedBlocks();
            foreach (var block in blockProvider.SpawnedBlocks)
            {
                if (Vector3.Distance(chopperPosition, block.transform.position) < block.Size)
                {
                    block.Chop();
                }
            }
        }
    }
}