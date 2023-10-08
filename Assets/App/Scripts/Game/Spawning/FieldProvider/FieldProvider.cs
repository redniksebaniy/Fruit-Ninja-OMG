using System;
using App.Scripts.Utilities.CameraAdapter;
using App.Scripts.Game.Spawning.FieldProvider.Scriptable;
using App.Scripts.Utilities.WeightHandler;
using UnityEngine;

namespace App.Scripts.Game.Spawning.FieldProvider
{
    public class FieldProvider : MonoBehaviour
    {
        [SerializeField] private FieldProviderScriptable providerScriptable;

        [SerializeField] private OrthographicCameraAdapter adapter;

        private readonly WeightHandler _weightHandler = new();

        private SpawnField[] _fields;

        private float[] _selectWeights;

        private void Start()
        {
            Init();
        }

        private void OnDrawGizmos()
        {
            Init();
        }

        private void Init()
        {
            CollectWeights();
            InitializeFields();
        }

        private void CollectWeights()
        {
            int count = providerScriptable.fields.Length;
            _selectWeights = new float[count];

            for (int i = 0; i < count; i++)
            {
                _selectWeights[i] = providerScriptable.fields[i].selectWeight;
            }
        }

        private void InitializeFields()
        {
            int count = providerScriptable.fields.Length;
            _fields = new SpawnField[count];

            for (int i = 0; i < count; i++)
            {
                var info = providerScriptable.fields[i];

                CountPosition(info, out Vector3 leftSide, out Vector3 rightSide);

                _fields[i] = new SpawnField(
                    leftSide, 
                    rightSide, 
                    info.minAngle, 
                    info.maxAngle, 
                    info.minStrength, 
                    info.maxStrength);
                
                DebugDrawField(_fields[i], info.fieldColor);
            }
        }

        private void CountPosition(FieldInfo info, out Vector3 left, out Vector3 right)
        {
            Vector3 fieldRight = Quaternion.Euler(0, 0, info.zRotation) * Vector3.right;

            right = adapter.GetAdaptedPositionByPercent(info.position + fieldRight * info.length);
            left = adapter.GetAdaptedPositionByPercent(info.position - fieldRight * info.length);
        }

        private void DebugDrawField(SpawnField field, Color color)
        {
            Debug.DrawLine(field.LeftEdge, field.RightEdge, color);

            Vector3 maxAngleDirection = Quaternion.Euler(0, 0, field.MaxAngle) * Vector3.right;
            Vector3 minAngleDirection = Quaternion.Euler(0, 0, field.MinAngle) * Vector3.right;
            
            Debug.DrawLine(field.LeftEdge, field.LeftEdge + minAngleDirection, color);
            Debug.DrawLine(field.LeftEdge, field.LeftEdge + maxAngleDirection, color);
            
            Debug.DrawLine(field.RightEdge, field.RightEdge + minAngleDirection, color);
            Debug.DrawLine(field.RightEdge, field.RightEdge + maxAngleDirection, color);
        }
        
        public SpawnField GetWeightedField()
        {
            int index = _weightHandler.GetWeightedIndex(_selectWeights);
            return _fields[index];
        }
    }

}