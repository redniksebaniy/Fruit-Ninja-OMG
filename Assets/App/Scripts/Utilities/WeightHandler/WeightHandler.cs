using UnityEngine;

namespace App.Scripts.Utilities.WeightHandler
{
    public class WeightHandler
    {
        public int GetWeightedIndex(float[] weights)
        {
            float weightSum = 0;
            foreach (float weight in weights) weightSum += weight;
            
            float randomValue = weightSum * Random.value;

            int id = 0;
            for (float sum = 0; sum < randomValue; id++)
            {
                sum += weights[id];
            }

            return --id;
        }
    }

}