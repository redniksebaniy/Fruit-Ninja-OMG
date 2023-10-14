using System;
using App.Scripts.Game.Spawning.FieldProvider;
using UnityEditor;
using UnityEngine;

namespace Editor.FieldDrawer
{
    [CustomEditor(typeof(FieldProvider))]
    public class FieldProviderEditor : UnityEditor.Editor
    {
        private FieldProvider _fieldProvider;

        private void OnEnable()
        {
            _fieldProvider = (FieldProvider) target;
            _fieldProvider.InitializeFields();
        }

        private void OnSceneGUI()
        {
            if (_fieldProvider.Fields == null) return;
            
            foreach (var field in _fieldProvider.Fields)
            {
                DebugDrawField(field);
            }
        }

        private void DebugDrawField(SpawnField field)
        {
            Handles.color = field.Color;
            Handles.DrawLine(field.LeftEdge, field.RightEdge);

            Vector3 maxAngleDirection = Quaternion.Euler(0, 0, field.MaxAngle) * Vector3.right;
            Vector3 minAngleDirection = Quaternion.Euler(0, 0, field.MinAngle) * Vector3.right;
            
            Handles.DrawLine(field.LeftEdge, field.LeftEdge + minAngleDirection);
            Handles.DrawLine(field.LeftEdge, field.LeftEdge + maxAngleDirection);
            
            Handles.DrawLine(field.RightEdge, field.RightEdge + minAngleDirection);
            Handles.DrawLine(field.RightEdge, field.RightEdge + maxAngleDirection);
            
        }
    }
}