using UnityEngine;

namespace App.Scripts.Game.Features.HealthHandler.Scriptable
{
    [CreateAssetMenu(fileName = "Health Options", menuName = "Scriptable Object/Health Config", order = 0)]
    public class HealthOptionsScriptable : ScriptableObject
    {
        public HealthOptions options;
    }
}