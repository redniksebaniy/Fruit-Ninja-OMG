using UnityEngine;

namespace App.Scripts.Game.Spawning.FieldProvider.Scriptable
{
    [CreateAssetMenu(fileName = "Field Container", menuName = "Scriptable Object/Spawning/Fields Config", order = 0)]
    public class FieldProviderScriptable : ScriptableObject
    {
        public FieldInfo[] fields;
    }
}
