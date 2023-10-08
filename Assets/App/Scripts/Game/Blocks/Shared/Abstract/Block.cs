using System;
using System.Collections;
using UnityEngine;

namespace App.Scripts.Game.Blocks.Shared.Abstract
{
    public abstract class Block : MonoBehaviour
    {
        [SerializeField] private float gravityCoefficient = 9.81f;

        private Vector3 _currentVelocity;

        private void FixedUpdate()
        {
            _currentVelocity.y -= gravityCoefficient * Time.fixedDeltaTime / 2;
            transform.position += _currentVelocity * Time.fixedDeltaTime;
        }

        public void SetForce(float angle, float strength)
        {
            Vector3 direction = Quaternion.Euler(0, 0, angle) * Vector3.right;
            _currentVelocity = direction * strength;
        }
    }
}
