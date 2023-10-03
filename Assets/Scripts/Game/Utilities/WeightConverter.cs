public class WeightConverter
{
    public static float[] ConvertWeightToPercent(float[] weights)
    {
        float weightSum = 0;
        for (int i = 0; i < weights.Length; i++) weightSum += weights[i];

        for (int i = 0; i < weights.Length; i++) weights[i] /= weightSum;

        return weights;
    }

    public static SpawnFieldInfo[] ConvertWeightToPercent(SpawnFieldInfo[] infos)
    {
        SpawnFieldInfo[] newInfos = (SpawnFieldInfo[]) infos.Clone();
        float[] weights = new float[infos.Length];

        for (int i = 0; i < infos.Length; i++) weights[i] = infos[i].sizeWeight;

        weights = ConvertWeightToPercent(weights);

        for (int i = 0; i < infos.Length; i++) newInfos[i].sizeWeight = weights[i];


        for (int i = 0; i < infos.Length; i++) weights[i] = infos[i].spawnChanceWeight;

        weights = ConvertWeightToPercent(weights);

        for (int i = 0; i < infos.Length; i++) newInfos[i].spawnChanceWeight = weights[i];

        return newInfos;
    }
}
