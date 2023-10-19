using App.Scripts.Game.Blocks.Shared.Abstract;
using App.Scripts.Game.Spawning.BlockProvider;
using UnityEngine;

namespace App.Scripts.Input.Chopper
{
    public class Chopper : MonoBehaviour
    {
        [SerializeField] private SwipeInputObserver.SwipeInputObserver observer;

        [SerializeField] private BlockProvider blockProvider;

        private Vector2 _previousPosition;
        private Vector2 _currentPosition;

        private void Update()
        {
            if (!observer.IsValidSwipe()) return;

            _previousPosition = _currentPosition;
            _currentPosition = transform.position;
            
            blockProvider.SpawnedBlocks.FindAll(IsTouching).ForEach(Chop);
        }
        
        private bool IsTouching(Block block)
        {
            return Vector2.Distance(block.transform.position, _currentPosition) < block.Size;
        }

        private void Chop(Block block) => block.Chop(_currentPosition - _previousPosition);
    }
}