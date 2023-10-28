using UnityEngine;

namespace App.Scripts.Game.Spawning.LevelHandler.Scriptable
{
    [CreateAssetMenu(fileName = "Level Options", menuName = "Scriptable Object/Spawning/Level Config", order = 0)]
    public class LevelOptionsScriptable : ScriptableObject
    {
        public LevelOptions level;
    }
}