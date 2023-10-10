using App.Scripts.Architecture.MonoInitializable;
using UnityEngine;

namespace App.Scripts.Utilities.CameraAdapter
{
    public class OrthographicCameraAdapter : MonoInitializable
    {
        [SerializeField] private Camera currentCamera;
        
        private float _verticalSize;

        private float _screenAspect;
        
        public override void Init()
        {
            _verticalSize = currentCamera.orthographicSize;
            _screenAspect = currentCamera.aspect;
        }

        public Vector3 GetAdaptedPositionByPercent(Vector3 percentPosition)
        {
            percentPosition *= _verticalSize;
            percentPosition.x *= _screenAspect;
            return percentPosition;
        }

        private void OnDrawGizmos() 
        {
            Init();
        }
    }
}