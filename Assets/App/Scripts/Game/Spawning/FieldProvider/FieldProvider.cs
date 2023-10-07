using App.Scripts.Game.CameraAdapter;
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

                _fields[i] = new SpawnField(leftSide, rightSide, info.minAngle, info.maxAngle, info.minStrength, info.maxStrength);
                Debug.DrawLine(leftSide, rightSide, info.fieldColor);
            }
        }

        private void CountPosition(FieldInfo info, out Vector3 left, out Vector3 right)
        {
            Vector3 fieldRight = Quaternion.Euler(0, 0, info.zRotation) * Vector3.right;

            right = adapter.GetAdaptedPositionByPercent(info.position + fieldRight * info.length);
            left = adapter.GetAdaptedPositionByPercent(info.position - fieldRight * info.length);
        }

        public SpawnField GetWeightedField()
        {
            int index = _weightHandler.GetWeightedIndex(_selectWeights);
            return _fields[index];
        }
    }

}