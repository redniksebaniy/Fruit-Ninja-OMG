using App.Scripts.Game.Blocks.Shared.Animator.Animations.Abstract;
using UnityEngine;

namespace App.Scripts.Game.Blocks.Shared.Animator.Animations
{
    public class ScaleTransformAnimation : BlockAnimation<Transform>
    {
        public override void UpdateAnimation(float dt)
        {
            CurrentState.localScale += Vector3.one * dt * AnimationSpeed;
        }
    }
}