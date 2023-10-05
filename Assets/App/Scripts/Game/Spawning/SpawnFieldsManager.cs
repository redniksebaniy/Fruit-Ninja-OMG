using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnFieldsManager : MonoBehaviour
{
    [SerializeField]
    private SpawnConfig config;

    private void Start()
    {
        InitFields();

        InvokeRepeating(nameof(SpawnBlocks), 0, 3f);
    }
        
    private void OnDrawGizmos()
    {
        InitFields();
    }
    
    private void SpawnBlocks()
    {
        int blockCount = Random.Range(config.minBlockCount, config.maxBlockCount);
        
        for (int i = 0; i < blockCount; i++)
        {
            SpawnField field = GetField();

            Spawn(field, new FruitFactory());
        }
    }
    
    private void Spawn(SpawnField field, BlockFactory factory)
    {
        Block block = factory.Create();
        block.transform.position = field.GetRandomPosition();
    
        float angle = Random.Range(field.minAngle, field.maxAngle);
        block.SetForce(angle, 10);
    }

    private SpawnField GetField()
    {
        int sideId = GetRandomIndex(config.sides, side => side.spawnChance);
        int fieldId = GetRandomIndex(config.sides[sideId].fields, field => field.spawnChance);

        return config.sides[sideId].fields[fieldId];
    }
    
    private int GetRandomIndex<T>(T[] variables, Func<T, float> chanceGetter)
    {
        float random = Random.value;
        int id = -1;
        float chanceSum = 0;
    
        while (chanceSum < random)
        {
            id++;
            chanceSum += chanceGetter(variables[id]);
        }
        
        return id;
    }

    private void InitFields()
    {
        ConvertToPercent(config.sides, (side) => side.spawnChance, (side, f) => side.spawnChance = f);

        foreach (var side in config.sides)
        {
            ConvertToPercent(side.fields, (field) => field.spawnChance, (field, f) => field.spawnChance = f);
            ConvertToPercent(side.fields, (field) => field.sizeWeight, (field, f) => field.sizeWeight = f);

            InitFieldPosition(side);
        }
    }
    
    private void ConvertToPercent<T>(T[] variables, Func<T, float> getter, Action<T, float> setter)
    {
        float[] chances = new float[variables.Length];
        float chanceSum = 0;
        
        for (int i = 0; i < variables.Length; i++)
        {
            chances[i] = getter(variables[i]);
            chanceSum += chances[i];
        }

        for (int i = 0; i < variables.Length; i++)
        {
            chances[i] /= chanceSum;
            setter(variables[i], chances[i]);
        }
    }
    
    private void InitFieldPosition(SpawnSide side)
    {
        Camera camera = Camera.main;
        Vector3 startPosition = Vector3.zero;
        Vector3 endPosition = Vector3.zero;

        switch (side.type)
        {
            case SideType.Bottom:
                startPosition = camera.ScreenToWorldPoint(Vector3.zero);
                endPosition = camera.ScreenToWorldPoint(new (camera.pixelWidth, 0));
                break;

            case SideType.Left:
                startPosition = camera.ScreenToWorldPoint(Vector3.zero);
                endPosition = camera.ScreenToWorldPoint(new(0, camera.pixelHeight));
                break;

            case SideType.Right:
                startPosition = camera.ScreenToWorldPoint(new (camera.pixelWidth, 0));
                endPosition = camera.ScreenToWorldPoint(new (camera.pixelWidth, camera.pixelHeight));
                break;
        }
        
        startPosition *= 1 + config.offsetPercent;
        endPosition *= 1 + config.offsetPercent;
        
        Vector3 left = startPosition;
        Vector3 right;
        
        float currentPercent = 0;
        for (int i = 0; i < side.fields.Length; i++)
        {
            currentPercent += side.fields[i].sizeWeight;
            right =  Vector3.Lerp(startPosition, endPosition, currentPercent);
            
            side.fields[i].SetSidePositions(left, right);
            
            Debug.DrawLine(left, right, GetChanceColor(side.fields[i].spawnChance));
            
            left = right;
        }
    }

    private Color GetChanceColor(float chancePercent)
    {
        return Color.Lerp(Color.red, Color.green, chancePercent);
    }
}
