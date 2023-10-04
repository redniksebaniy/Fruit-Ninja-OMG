public class WeightConverter
{
    public float[] ConvertWeightToPercent(float[] weights)
    {
        float weightSum = 0;
        for (int i = 0; i < weights.Length; i++) weightSum += weights[i];

        for (int i = 0; i < weights.Length; i++) weights[i] /= weightSum;

        return weights;
    }
}
