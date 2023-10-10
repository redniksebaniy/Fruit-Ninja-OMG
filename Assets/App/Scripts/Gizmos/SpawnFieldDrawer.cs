using App.Scripts.Game.Spawning.FieldProvider;
using UnityEngine;

namespace App.Scripts.Gizmos
{
    public class SpawnFieldDrawer : MonoBehaviour
    {
        [SerializeField] private FieldProvider provider;
        
        private void OnDrawGizmos()
        {
            if (provider.Fields == null) return;

            foreach (var field in provider.Fields)
            {
                DebugDrawField(field);
            }
        }

        private void DebugDrawField(SpawnField field)
        {
            Debug.DrawLine(field.LeftEdge, field.RightEdge, field.Color);

            Vector3 maxAngleDirection = Quaternion.Euler(0, 0, field.MaxAngle) * Vector3.right;
            Vector3 minAngleDirection = Quaternion.Euler(0, 0, field.MinAngle) * Vector3.right;
            
            Debug.DrawLine(field.LeftEdge, field.LeftEdge + minAngleDirection, field.Color);
            Debug.DrawLine(field.LeftEdge, field.LeftEdge + maxAngleDirection, field.Color);
            
            Debug.DrawLine(field.RightEdge, field.RightEdge + minAngleDirection, field.Color);
            Debug.DrawLine(field.RightEdge, field.RightEdge + maxAngleDirection, field.Color);
        }
    }
}