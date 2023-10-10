using UnityEngine;

namespace App.Scripts.Game.Blocks.Shared.Abstract
{
    public abstract class Block : MonoBehaviour
    {
        [SerializeField] private float gravityCoefficient = 9.81f;

        private Vector3 _currentVelocity;
        
        private void Update()
        {
            UpdatePosition();
        }

        private void UpdatePosition()
        {
            _currentVelocity.y -= gravityCoefficient * Time.deltaTime / 2;
            transform.position += _currentVelocity * Time.deltaTime;
        }
        
        public void SetForce(float angle, float strength)
        {
            Vector3 direction = Quaternion.Euler(0, 0, angle) * Vector3.right;
            _currentVelocity = direction * strength;
        }


        private void OnMouseOver()
        {
            Destroy(gameObject);
        }

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}
