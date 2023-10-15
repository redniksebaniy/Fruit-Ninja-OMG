using System;
using UnityEngine;

namespace App.Scripts.Game.Spawning.FieldProvider.Scriptable
{
    [Serializable]
    public class FieldInfo
    {
        [Header("Debug Options")] public Color fieldColor;

        [Header("Transform")] public Vector3 position;

        [Range(-180, 180)] public int zRotation;

        [Range(0, 1.415f)] public float length;

        [Header("Spawn Options")] [Min(0)] public int selectWeight;

        [Range(-180, 180)] public int minAngle;

        [Range(-180, 180)] public int maxAngle;

        [Min(0)] public int minStrength;
        
        [Min(0)] public int maxStrength;
        
    }
}