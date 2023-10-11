using UnityEngine;

namespace App.Scripts.Input.Cursor
{
    public class Cursor : MonoBehaviour
    {
        [SerializeField] private Camera usingCamera;

        private void Update()
        {
            Vector3 mousePos = usingCamera.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
            mousePos.z = transform.position.z;
            transform.position = mousePos;
        }
    }
}