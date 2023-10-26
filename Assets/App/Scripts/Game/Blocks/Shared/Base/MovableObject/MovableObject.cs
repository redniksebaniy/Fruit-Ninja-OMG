using App.Scripts.Architecture.MonoInitializable;
using UnityEngine;

namespace App.Scripts.Game.Blocks.Shared.Base.MovableObject
{
    public abstract class MovableObject : MonoInitializable
    {
        [SerializeField] [Min(0)] private float gravityCoefficient = 9.81f;
        
        private Vector3 _currentVelocity;
        
        private void Update()
        {
            UpdatePosition();
        }

        private void UpdatePosition()
        {
            _currentVelocity.y -= gravityCoefficient * Time.deltaTime;
            transform.position += _currentVelocity * Time.deltaTime;
        }
        
        public void AddForce(float angle, float strength)
        {
            _currentVelocity += Quaternion.Euler(0, 0, angle) * Vector3.right * strength;
        }
        
        public void SetForce(float angle, float strength)
        {
            _currentVelocity = Quaternion.Euler(0, 0, angle) * Vector3.right * strength;
        }
    }
}
