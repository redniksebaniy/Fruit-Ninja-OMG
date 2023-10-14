using App.Scripts.Game.Blocks.Shared.Animator.Animations.Abstract;
using UnityEngine;

namespace App.Scripts.Game.Blocks.Shared.Animator.Animations
{
    public class RotationTransformAnimation : BlockAnimation<Transform>
    {
        public override void UpdateAnimation(float dt)
        {
            CurrentState.rotation *= Quaternion.Euler(0, 0, dt * 360 * AnimationSpeed);
        }
    }
}