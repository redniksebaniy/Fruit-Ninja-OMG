using System;
using UnityEngine;

[Serializable]
public struct SpawnFieldInfo 
{
    [SerializeField]
    [Min(0)]
    public float spawnChanceWeight;

    [SerializeField]
    [Min(0)]
    public float sizeWeight;

    [SerializeField]
    [Range(0, 360)]
    public float minAngle;

    [SerializeField]
    [Range(0, 360)]
    public float maxAngle;
}
