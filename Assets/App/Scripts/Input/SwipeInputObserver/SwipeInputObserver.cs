using UnityEngine;

namespace App.Scripts.Input.SwipeInputObserver
{
    public class SwipeInputObserver : MonoBehaviour
    {
        [SerializeField] private Cursor.Cursor cursor;
        
        [SerializeField] private Camera usingCamera;

        [SerializeField] [Min(0)] private float minSpeed;
        [SerializeField] [Min(0)] private float minDistance;

        private Vector2 _previousPosition;
        private Vector2 _currentPosition;

        private float _currentSpeed;
        private float _currentDistance;

        public void Update()
        {
            if (cursor.IsPressed) UpdateSwipeInfo();
            else ResetSwipeInfo();
        }

        private void ResetSwipeInfo()
        {
            _currentSpeed = 0;
            _currentDistance = 0;
            _currentPosition = usingCamera.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
        }
        
        private void UpdateSwipeInfo()
        {
            _previousPosition = _currentPosition;
            _currentPosition = usingCamera.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
            _currentSpeed = (_currentPosition - _previousPosition).magnitude;
            _currentDistance += _currentSpeed;
        }

        public bool IsValidSwipe()
        {
            return _currentSpeed >= minSpeed && _currentDistance >= minDistance;
        }
    }
}