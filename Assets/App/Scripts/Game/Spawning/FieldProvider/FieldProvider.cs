using System;
using App.Scripts.Architecture.MonoInitializable;
using App.Scripts.Utilities.CameraAdapter;
using App.Scripts.Game.Spawning.FieldProvider.Scriptable;
using App.Scripts.Utilities.WeightConverter;
using UnityEngine;

namespace App.Scripts.Game.Spawning.FieldProvider
{
    public class FieldProvider : MonoInitializable
    {
        [SerializeField] private FieldProviderScriptable providerScriptable;

        [SerializeField] private OrthographicCameraAdapter adapter;

        private readonly WeightConverter _weightConverter = new();

        public SpawnField[] Fields { get; private set; }

        private int[] _selectWeights;

        public override void Init()
        {
            CollectWeights();
            InitializeFields();
        }

        private void CollectWeights()
        {
            int count = providerScriptable.fields.Length;
            _selectWeights = new int[count];

            for (int i = 0; i < count; i++)
            {
                _selectWeights[i] = providerScriptable.fields[i].selectWeight;
            }
        }

        public void InitializeFields()
        {
            int count = providerScriptable.fields.Length;
            Fields = new SpawnField[count];

            for (int i = 0; i < count; i++)
            {
                var info = providerScriptable.fields[i];

                CountPosition(info, out Vector3 leftSide, out Vector3 rightSide);

                Fields[i] = new SpawnField(
                    leftSide, 
                    rightSide, 
                    info.minAngle, 
                    info.maxAngle, 
                    info.minStrength, 
                    info.maxStrength,
                    info.fieldColor);
            }
        }

        private void CountPosition(FieldInfo info, out Vector3 left, out Vector3 right)
        {
            Vector3 fieldRight = Quaternion.Euler(0, 0, info.zRotation) * Vector3.right;
            left = info.position + fieldRight * info.length;
            right = info.position - fieldRight * info.length + Vector3.forward;
            adapter.GetAdaptedPositionByPercent(ref left);
            adapter.GetAdaptedPositionByPercent(ref right);
        }
        
        public SpawnField GetWeightedField()
        {
            int index = _weightConverter.GetWeightedIndex(_selectWeights);
            return Fields[index];
        }
    }

}