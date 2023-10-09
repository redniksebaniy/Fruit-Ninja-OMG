using System;
using System.Collections.Generic;
using App.Scripts.Game.Blocks.Shared.Animator.Animations.Abstract;
using UnityEngine;
using Random = UnityEngine.Random;

namespace App.Scripts.Game.Blocks.Shared.Animator
{
    public class BlockAnimator : MonoBehaviour
    {
        [SerializeField] private string animationsPath;
        [SerializeField] private List<string> animations;
        
        [SerializeField] private float minSpeed;
        [SerializeField] private float maxSpeed;
        
        private BlockAnimation[] _currentAnimations;
        
        private void Start()
        {
            Init();
        }

        private void Init()
        {
            var animationsCount = Random.Range(0, animations.Count) + 1;
            _currentAnimations = new BlockAnimation[animationsCount];
            
            for (int i = 0; i < animationsCount; i++)
            {
                var randomIndex = Random.Range(0, animations.Count);
            
                Type type = Type.GetType(animationsPath + animations[randomIndex]);
                _currentAnimations[i] = (BlockAnimation) gameObject.AddComponent(type);
                _currentAnimations[i].Init(transform, -minSpeed, maxSpeed);

                animations.RemoveAt(randomIndex);
            }
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