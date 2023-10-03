using UnityEngine;

public class SpawnField
{
    private SpawnFieldInfo spawnInfo;

    public Vector2 LeftSidePosition { get; private set; }

    public Vector2 RightSidePosition { get; private set; }

    public float SpawnChance 
    { 
        get
        {
            return spawnInfo.spawnChanceWeight;
        }

        private set
        {
            spawnInfo.spawnChanceWeight = value;
        }
    }


    public SpawnField(SpawnFieldInfo info)
    {
        spawnInfo = info;
    }

    public void Spawn(BlockFactory factory)
    {
        Block block = factory.Create();
        block.transform.position = GetRandomPosition();

        float angle = Random.Range(spawnInfo.minAngle, spawnInfo.maxAngle);
        block.SetForce(angle, 10);
    }

    public void SetSidePositions(Vector2 left, Vector2 right)
    {
        LeftSidePosition = left;
        RightSidePosition = right;
    }

    private Vector2 GetRandomPosition()
    {
        return Vector2.Lerp(LeftSidePosition, RightSidePosition, Random.value);
    }
}
