using App.Scripts.Game.Blocks.Shared.Animator.Animations.Abstract;
using UnityEngine;

namespace App.Scripts.Game.Blocks.Shared.Animator.Animations
{
    public class RotationAnimation : BlockAnimation
    {
        public override void UpdateAnimation(float dt)
        {
            CurrentState.localEulerAngles += new Vector3(0, 0, dt * 360 * AnimationSpeed);
        }
    }
}