using UnityEngine;

namespace App.Scripts.Game.Blocks.Shared.Shadow.Scriptable
{
    [CreateAssetMenu(fileName = "Shadow Options", menuName = "Scriptable Object/Blocks/Shadow Config", order = 0)]
    public class ShadowOptionsScriptable : ScriptableObject
    {
        public Vector3 shadowOffset;
        
        [Min(1)] 
        public float offsetMultiplier;

        [Range(0, 1)] 
        public float shadowIntensity;
    }
}