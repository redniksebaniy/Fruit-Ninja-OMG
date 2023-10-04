using System;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class SpawnField
{
    [Min(0)] public float spawnChanceWeight;

    [Min(0)] public float sizeWeight;

    [Range(0, 360)] public float minAngle;

    [Range(0, 360)] public float maxAngle;
    
    private Vector3 LeftSidePosition;

    private Vector3 RightSidePosition;

    public void SetSidePositions(Vector3 left, Vector3 right)
    {
        LeftSidePosition = left;
        RightSidePosition = right;
    }

    public Vector3 GetRandomPosition()
    {
        return Vector3.Lerp(LeftSidePosition, RightSidePosition, Random.value);
    }
    
    //gizmos??
}
