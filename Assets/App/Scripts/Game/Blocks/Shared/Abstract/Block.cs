using App.Scripts.Architecture.MonoInitializable;
using UnityEngine;

namespace App.Scripts.Game.Blocks.Shared.Abstract
{
    public abstract class Block : MovableObject.MovableObject, IChopable
    {
        [Min(0)] public readonly float size = 1f;
        
        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }

        public abstract void Chop();
    }
}
