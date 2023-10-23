using System;
using UnityEngine;

namespace App.Scripts.Game.Blocks.Shared.Base
{
    public abstract class Block : MovableObject.MovableObject, IChopable
    {
        [SerializeField] 
        [Min(0)] 
        private float size = 1f;
        public float Size => size * transform.localScale.z;

        public bool isPositive = true;
        
        public event Action<Vector2> OnChop;
        public event Action OnMiss;

        private bool _isChopped;
        
        private void OnBecameInvisible()
        {
            if (_isChopped || gameObject == null) return;
            
            OnMiss?.Invoke();
            Destroy(gameObject);
        }

        public void Chop(Vector2 direction)
        {
            _isChopped = true;
            
            OnChop?.Invoke(direction);
            Destroy(gameObject);
        }
    }
}
