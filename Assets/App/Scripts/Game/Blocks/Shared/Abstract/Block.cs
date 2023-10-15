using System;
using UnityEngine;

namespace App.Scripts.Game.Blocks.Shared.Abstract
{
    public abstract class Block : MovableObject.MovableObject, IChopable
    {
        [SerializeField] [Min(0)] private float size = 1f;
        public float Size
        {
            get
            {
                return size * transform.lossyScale.z;
            }
            private set
            {
                size = value;
            }
        }

        private bool _isChopped;
        
        public event Action OnChop;
        public event Action OnMiss;

        private void OnBecameInvisible()
        {
            if (_isChopped) return;
            
            OnMiss?.Invoke();
            Destroy(gameObject);
        }

        public void Chop()
        {
            _isChopped = true;
            OnChop?.Invoke();
            Destroy(gameObject);
        }
    }
}
