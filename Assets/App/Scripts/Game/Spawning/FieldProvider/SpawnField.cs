using UnityEngine;

namespace App.Scripts.Game.Spawning.FieldProvider
{
    public class SpawnField
    {
        private Vector3 leftEdge;

        private Vector3 rightEdge;

        private float minAngle;
        
        private float maxAngle;

        private float minStrength;
        
        private float maxStrength;

        public SpawnField(Vector3 leftEdge, Vector3 rightEdge, float minAngle, float maxAngle, float minStrength, float maxStrength)
        {
            this.leftEdge = leftEdge;
            this.rightEdge = rightEdge;
            this.minAngle = minAngle;
            this.maxAngle = maxAngle;
            this.minStrength = minStrength;
            this.maxStrength = maxStrength;
        }

        public Vector3 GetRandomPosition()
        {
            return Vector3.Lerp(leftEdge, rightEdge, Random.value);
        }

        public float GetRandomAngle()
        {
            return Mathf.Lerp(minAngle, maxAngle, Random.value);
        }

        public float GetRandomStrength()
        {
            return Mathf.Lerp(minStrength, maxStrength, Random.value);
        }
    }
}