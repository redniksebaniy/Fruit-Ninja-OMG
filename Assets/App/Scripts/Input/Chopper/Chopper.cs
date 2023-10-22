using System;
using App.Scripts.Game.Blocks.Shared.Base;
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

        private void Start()
        {
            _previousPosition = _currentPosition = transform.position;
        }
        
        private void Update()
        {
            _previousPosition = _currentPosition;
            _currentPosition = transform.position;
            
            if (!observer.IsValidSwipe()) return;

            blockProvider.SpawnedBlocks.FindAll(IsTouching).ForEach(Chop);
        }

        private bool IsTouching(Block block)
        {
            Vector2 blockPosition = (Vector2) block.transform.position - _previousPosition;
            Vector2 chopperPosition = _currentPosition - _previousPosition;
            
            var angle = Vector2.Angle(blockPosition, chopperPosition);

            float blockMagnitude = blockPosition.magnitude;
            
            return blockMagnitude * Mathf.Abs(Mathf.Sin(angle)) < block.Size && 
                   blockMagnitude * Mathf.Abs(Mathf.Cos(angle)) < chopperPosition.magnitude;
        }

        private void Chop(Block block) => block.Chop(_currentPosition - _previousPosition);
    }
}