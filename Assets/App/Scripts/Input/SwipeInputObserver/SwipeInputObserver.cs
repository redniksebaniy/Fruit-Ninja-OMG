using System;
using App.Scripts.Architecture.MonoInitializable;
using UnityEngine;

namespace App.Scripts.Input.SwipeInputObserver
{
    public class SwipeInputObserver : MonoBehaviour
    {
        [SerializeField] [Min(0)] private float minSpeed;
        [SerializeField] [Min(0)] private float minDistance;
        
        private Vector3 _previousPosition;
        private Vector3 _currentPosition;

        private float _currentSpeed;
        private float _currentDistance;

        private bool _isPressed;

        public void Update()
        {
            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                _isPressed = true;
                InitSwipeInfo();
            }
            
            if (UnityEngine.Input.GetMouseButtonUp(0))
            {
                _isPressed = false;
            }
            
            if (_isPressed)
            {
                UpdateSwipeInfo();
            }
        }

        private void InitSwipeInfo()
        {
            _currentSpeed = 0;
            _currentDistance = 0;
            _currentPosition = UnityEngine.Input.mousePosition;
        }
        
        private void UpdateSwipeInfo()
        {
            _previousPosition = _currentPosition;
            _currentPosition = UnityEngine.Input.mousePosition;
            
            _currentSpeed = (_currentPosition - _previousPosition).magnitude;
            _currentDistance += _currentSpeed;
        }

        public bool IsValidSwipe()
        {
            return _currentSpeed >= minSpeed && _currentDistance >= minDistance;
        }
    }
}