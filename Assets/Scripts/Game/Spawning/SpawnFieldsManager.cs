using UnityEngine;

public class SpawnFieldsManager : MonoBehaviour
{
    [SerializeField]
    private SpawnFieldInfo[] bottomSpawnFieldsInfo;

    private SpawnField[] bottomSpawnFields;

    private void Start()
    {
        InitFields();

        InvokeRepeating(nameof(SpawnUnit), 0, 1f);
    }

    private void SpawnUnit()
    {
        float random = Random.value;
        int fieldID = -1;
        float chancesSum = 0;

        while (chancesSum < random)
        {
            fieldID++;
            chancesSum += bottomSpawnFields[fieldID].SpawnChance;
        }

        bottomSpawnFields[fieldID].Spawn(new FruitFactory());
    }

    private void OnDrawGizmos()
    {
        var fields = WeightConverter.ConvertWeightToPercent(bottomSpawnFieldsInfo);

        Camera camera = Camera.main;
        Vector3 leftPosition = camera.ScreenToWorldPoint(Vector2.zero);
        Vector3 rightPosition;

        float currentPercent = 0;
        for (int i = 0; i < fields.Length; i++)
        {
            currentPercent += fields[i].sizeWeight;
            rightPosition = camera.ScreenToWorldPoint(new Vector2(camera.pixelWidth * currentPercent, 0));

            Gizmos.color = GetChanceColor(fields[i].spawnChanceWeight);
            Gizmos.DrawLine(leftPosition, rightPosition);

            leftPosition = rightPosition;
        }
    }

    private Color GetChanceColor(float chancePercent)
    {
        return Color.Lerp(Color.red, Color.green, chancePercent);
    }

    private void InitFields()
    {
        bottomSpawnFields = new SpawnField[bottomSpawnFieldsInfo.Length];

        var percentInfos = WeightConverter.ConvertWeightToPercent(bottomSpawnFieldsInfo);

        for (int i = 0; i < bottomSpawnFields.Length; i++)
        {
            bottomSpawnFields[i] = new SpawnField(percentInfos[i]);
        }

        Camera camera = Camera.main;
        Vector3 leftPosition = camera.ScreenToWorldPoint(Vector2.zero);
        Vector3 rightPosition;

        float currentPercent = 0;
        for (int i = 0; i < bottomSpawnFields.Length; i++)
        {
            currentPercent += percentInfos[i].sizeWeight;
            rightPosition = camera.ScreenToWorldPoint(new Vector2(camera.pixelWidth * currentPercent, 0));

            bottomSpawnFields[i].SetSidePositions(leftPosition, rightPosition);
            leftPosition = rightPosition;
        }
    }
}
