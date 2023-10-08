using UnityEngine;

namespace App.Scripts.Game.Spawning.FieldProvider
{
    public class SpawnField
    {
        public readonly Vector3 LeftEdge;

        public readonly Vector3 RightEdge;

        public readonly float MinAngle;
        
        public readonly float MaxAngle;

        public readonly float MinStrength;
        
        public readonly float MaxStrength;

        public SpawnField(Vector3 leftEdge, Vector3 rightEdge, float minAngle, float maxAngle, float minStrength, float maxStrength)
        {
            LeftEdge = leftEdge;
            RightEdge = rightEdge;
            MinAngle = minAngle;
            MaxAngle = maxAngle;
            MinStrength = minStrength;
            MaxStrength = maxStrength;
        }

        public Vector3 GetRandomPosition()
        {
            return Vector3.Lerp(LeftEdge, RightEdge, Random.value);
        }

        public float GetRandomAngle()
        {
            return Mathf.Lerp(MinAngle, MaxAngle, Random.value);
        }

        public float GetRandomStrength()
        {
            return Mathf.Lerp(MinStrength, MaxStrength, Random.value);
        }
    }
}