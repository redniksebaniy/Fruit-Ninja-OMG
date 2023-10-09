using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace App.Scripts.Game.Blocks.Shared.Animator.Animations.Abstract
{
    [Serializable]
    public abstract class BlockAnimation : MonoBehaviour
    {
        protected float AnimationSpeed;

        protected Transform CurrentState;

        public void Init(Transform state, float minSpeed,  float maxSpeed)
        {
            CurrentState = state;
            AnimationSpeed = Mathf.Lerp(minSpeed, maxSpeed, Random.value);
        }
        
        public abstract void UpdateAnimation(float dt);
    }
}