using UnityEngine;

namespace App.Scripts.Game.Features.ForcePointProvider.Base.Scriptable
{
    [CreateAssetMenu(fileName = "Force Point Options", menuName = "Scriptable Object/Force Points Config", order = 0)]
    public class ForcePointScriptable : ScriptableObject
    {
        [Min(0)] public float affectRadius;
        
        [Min(0)] public float middleAffectRadius;

        [Min(0)] public float strengthMultiplier;
        
        [Tooltip("Duration of force action. Set 0 to create an impulse type force.")]
        [Min(0)] public float forceDuration;

        public bool affectOnlyPositive;
    }
}