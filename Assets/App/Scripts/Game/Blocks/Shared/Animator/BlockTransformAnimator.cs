using System.Collections.Generic;
using App.Scripts.Architecture.MonoInitializable;
using App.Scripts.Game.Blocks.Shared.Animator.Animations.Abstract;
using UnityEngine;

namespace App.Scripts.Game.Blocks.Shared.Animator
{
    public class BlockTransformAnimator : MonoInitializable
    {
        [SerializeField] private List<BlockAnimation<Transform>> animations;
        
        [SerializeField] [Min(0)] private float minSpeed;
        [SerializeField] [Min(0)] private float maxSpeed;
        
        private BlockAnimation<Transform>[] _currentAnimations;

        public override void Init()
        {
            animations.Sort((block1, block2) => Random.Range(0, animations.Count));
            
            var animationsCount = Random.Range(1, animations.Count);
            _currentAnimations = new BlockAnimation<Transform>[animationsCount];
            
            for (int i = 0; i < animationsCount; i++)
            {
                _currentAnimations[i] = animations[i];
                _currentAnimations[i].Init(transform, GetRandomSpeed());
            }

            for (int i = animationsCount; i < animations.Count; i++)
            {
                Destroy(animations[i]);
                animations.RemoveAt(i);
            }
        }

        private float GetRandomSpeed()
        {
            int direction = (Random.Range(0, 2) % 2 == 0) ? 1 : -1;
            return Mathf.Lerp(minSpeed, maxSpeed, Random.value) * direction;
        }
        
        private void Update()
        {
            foreach (var _animation in _currentAnimations)
            {
                _animation.UpdateAnimation(Time.deltaTime);
            }
        }
    }
}