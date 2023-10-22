using System;
using UnityEngine;

namespace App.Scripts.Game.Blocks.Shared.Animator.Animations.Base
{
    [Serializable]
    public abstract class BlockAnimation<T> : MonoBehaviour
    {
        protected float AnimationSpeed;

        protected T CurrentState;

        public void Init(T state, float speed)
        {
            CurrentState = state;
            AnimationSpeed = speed;
        }
        
        public abstract void UpdateAnimation(float dt);
    }
}