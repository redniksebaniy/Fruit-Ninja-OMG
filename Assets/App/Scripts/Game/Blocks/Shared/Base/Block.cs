using System;
using System.Collections;
using UnityEngine;

namespace App.Scripts.Game.Blocks.Shared.Base
{
    public abstract class Block : MovableObject.MovableObject, IChopable
    {
        [SerializeField] [Min(0)] private float size = 1f;
        
        [SerializeField] private bool isPositive = true;
        
        [SerializeField] private bool isDestroyableByChop = true;
        
        [SerializeField] [Min(0)] private float invulnerabilityDuration;
        
        public float Size => size * transform.localScale.z;
        public bool IsPositive => isPositive;

        public bool IsDestroyableByChop => isDestroyableByChop;

        private bool _isInvulnerable;
        
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
            if (_isInvulnerable) return;
            
            OnChop?.Invoke(direction);
            
            if (isDestroyableByChop)
            {
                _isChopped = true;
                Destroy(gameObject);
            }
        }

        public void SetInvulnerability()
        {
            if (_isInvulnerable) return;
            
            _isInvulnerable = true;
            StartCoroutine(WaitForVulnerability());
        }

        private IEnumerator WaitForVulnerability()
        {
            yield return new WaitForSeconds(invulnerabilityDuration);
            _isInvulnerable = false;
        }
    }
}
