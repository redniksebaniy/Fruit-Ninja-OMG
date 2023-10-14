using UnityEngine;

namespace App.Scripts.Input.Cursor
{
    public class Cursor : MonoBehaviour
    {
        [SerializeField] private Camera usingCamera;
        
        [SerializeField] private TrailRenderer trailRenderer;

        public bool IsPressed { get; private set; }

        private void Update()
        {
            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                IsPressed = true;
                trailRenderer.enabled = true;
            }
            else if (UnityEngine.Input.GetMouseButtonUp(0))
            {
                IsPressed = false;
                trailRenderer.enabled = false;
            }

            Vector2 mousePos = usingCamera.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
            transform.position = mousePos;
        }
    }
}