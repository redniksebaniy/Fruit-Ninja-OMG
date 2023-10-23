using System;
using UnityEngine;

namespace App.Scripts.Game.Blocks.Shared.Base
{
    public abstract class Block : MovableObject.MovableObject, IChopable
    {
        [SerializeField] [Min(0)] private float size = 1f;
        
        [SerializeField] private bool isPositive = true;
        
        [SerializeField] private bool isDestroyable = true;
        
        public float Size => size * transform.localScale.z;
        public bool IsPositive => isPositive;

        public bool IsDestroyable => isDestroyable;
        
        [HideInInspector]
        public bool isActive = true;
        
        public event Action<Vector2> OnChop;
        public event Action OnMiss;

        private bool _isChopped;
        
        private void OnBecameInvisible()
        {
            if (_isChopped || gameObject == null) return;
            
            OnMiss?.Invoke();
            Destroy(gameObject);
        }

        public virtual void Chop(Vector2 direction)
        {
            if (!isActive) return;
            
            _isChopped = true;
            
            OnChop?.Invoke(direction);
            if (isDestroyable) Destroy(gameObject);
        }
    }
}
