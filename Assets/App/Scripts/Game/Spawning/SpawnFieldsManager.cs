using UnityEngine;

public class SpawnFieldsManager : MonoBehaviour
{
    [SerializeField]
    private SpawnConfig config;

    private void Start()
    {
        InitFields();

        InvokeRepeating(nameof(SpawnUnit), 0, 1f);
    }

    private void Spawn(SpawnField field, BlockFactory factory)
    {
        Block block = factory.Create();
        block.transform.position = field.GetRandomPosition();
    
        float angle = Random.Range(field.minAngle, field.maxAngle);
        block.SetForce(angle, 10);
    }

    private void SpawnUnit()
    {
        SpawnField field = GetField(GetSide());
        
        Spawn(field, new FruitFactory());
    }
    
    private SpawnField GetField(SpawnSide side)
    {
        float random = Random.value;
        int fieldID = -1;
        float chancesSum = 0;
    
        while (chancesSum < random)
        {
            fieldID++;
            chancesSum += side.fields[fieldID].spawnChanceWeight;
        }
        
        return side.fields[fieldID];
    }

    private SpawnSide GetSide()
    {
        float random = Random.value;
        int fieldID = -1;
        float chancesSum = 0;
    
        while (chancesSum < random)
        {
            fieldID++;
            chancesSum += config.sides[fieldID].spawnChanceWeight;
        }

        return config.sides[fieldID];
    }

    private void InitFields()
    {
        foreach (var side in config.sides)
        {
            if (!side.isEnabled) continue;
                
            ConvertFieldSpawnChance(side);
            ConvertFieldSize(side);
            InitFieldPosition(side);
        }
    }

    private void ConvertFieldSpawnChance(SpawnSide side)
    {
        float[] chances = new float[side.fields.Length];
        float chanceSum = 0;
        for (int i = 0; i < side.fields.Length; i++)
        {
            chances[i] = side.fields[i].spawnChanceWeight;
            chanceSum += chances[i];
        }

        for (int i = 0; i < side.fields.Length; i++)
        {
            chances[i] /= chanceSum;
            side.fields[i].spawnChanceWeight = chances[i];
        }
    }
    
    private void ConvertFieldSize(SpawnSide side)
    {
        float[] chances = new float[side.fields.Length];
        float chanceSum = 0;
        for (int i = 0; i < side.fields.Length; i++)
        {
            chances[i] = side.fields[i].sizeWeight;
            chanceSum += chances[i];
        }

        for (int i = 0; i < side.fields.Length; i++)
        {
            chances[i] /= chanceSum;
            side.fields[i].sizeWeight = chances[i];
        }
    }

    private void InitFieldPosition(SpawnSide side)
    {
        Camera camera = Camera.main;
        Vector3 startPosition = Vector3.zero;
        Vector3 endPosition = Vector3.zero;
        Vector2 offset = Vector2.zero;

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

        Vector3 left = startPosition;
        Vector3 right;
        
        float currentPercent = 0;
        for (int i = 0; i < side.fields.Length; i++)
        {
            currentPercent += side.fields[i].sizeWeight;
            
            right =  Vector3.Lerp(startPosition, endPosition, currentPercent);
            
            side.fields[i].SetSidePositions(left, right);
            
            Debug.DrawLine(left, right, GetChanceColor(side.fields[i].spawnChanceWeight));
            
            left = right;
        }
    }

    private void OnDrawGizmos()
    {
        InitFields();
    }

    private Color GetChanceColor(float chancePercent)
    {
        return Color.Lerp(Color.red, Color.green, chancePercent);
    }
}
