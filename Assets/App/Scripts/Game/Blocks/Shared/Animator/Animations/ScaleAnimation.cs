using App.Scripts.Game.Blocks.Shared.Animator.Animations.Abstract;
using UnityEngine;

namespace App.Scripts.Game.Blocks.Shared.Animator.Animations
{
    public class ScaleAnimation : BlockAnimation
    {
        public override void UpdateAnimation(float dt)
        {
            CurrentState.localScale += Vector3.one * dt * AnimationSpeed;
            CurrentState.position -= Vector3.forward * dt * AnimationSpeed;
        }
    }
}